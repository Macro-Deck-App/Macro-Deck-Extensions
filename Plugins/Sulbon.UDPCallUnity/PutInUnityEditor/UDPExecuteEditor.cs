#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Net;
using System.Net.Sockets;
using System.Threading;

[InitializeOnLoad]
public class UDPExecuteEditor : EditorWindow
{
    static public int port = 8193;

    static List<string> CommandsQ = new List<string>();

    static DateTime LastRecvTime;


    [MenuItem("Tools/程序专用/临时/UDPExecuteEditor %#t")]
    static public void OpenOpenTrackerMoveComponentInspector()
    {
        EditorWindow.GetWindow<UDPExecuteEditor>("UDPExecuteEditor");
    }


    static UDPExecuteEditor()
    {
        UDPReceive.port = port;
        UDPReceive.EnsureEnable(RecvData);
        EditorApplication.update += UDPExecuteEditor.Update;
        EditorApplication.quitting += ()=>
        {
            UDPReceive.CheckDisable();
            EditorApplication.update -= UDPExecuteEditor.Update; 
        };
    }



    public void OnGUI()
    {
        port = EditorGUILayout.IntField("port", port);


        if(GUILayout.Button("Restart"))
        {
            UDPReceive.port = port;
            UDPReceive.CheckDisable();
            UDPReceive.EnsureEnable(RecvData);
        }

        GUILayout.Label("Last Recved:" + LastRecvTime);
    }

    public static void Update()
    {
        if (CommandsQ.Count <= 0)
            return;

        Debug.Log("Executing:" + CommandsQ[0]);
        EditorApplication.ExecuteMenuItem(CommandsQ[0]);
        CommandsQ.RemoveAt(0);

    }

    static public void RecvData(byte[] buffer)
    {
        LastRecvTime = DateTime.Now;
        var recvString = System.Text.Encoding.UTF8.GetString(buffer);
        lock (CommandsQ)
        {
            CommandsQ.Add(recvString);
        }
    }

}



public class UDPReceive
{

    // receiving Thread
    static Thread receiveThread;

    // udpclient object
    static UdpClient client;

    static public int port;
    
    static public string recvString = "";

    public delegate void CBRecv(byte[] buf);
    static CBRecv recvFunc;

    // start from unity3d
    static public void EnsureEnable(CBRecv recvFunc_)
    {
        recvFunc = recvFunc_;
        if (receiveThread == null)
            init();
    }

    static public void CheckDisable()
    {
        if (receiveThread != null)
            Release();
    }


    // init
    static void init()
    {
        recvString = "";

        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    // receive thread 
    static void ReceiveData()
    {
        client = new UdpClient(port);
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
                if(recvFunc!=null)
                {
                    recvFunc(data);
                }
            }
            catch (Exception err)
            {
                Debug.LogError(err.ToString());
            }

            Thread.Sleep(50);
        }
    }

    static void Release()
    {
        if (receiveThread != null)
        {
            receiveThread.Abort();
            receiveThread = null;
        }
        client.Close();
    }
}
#endif