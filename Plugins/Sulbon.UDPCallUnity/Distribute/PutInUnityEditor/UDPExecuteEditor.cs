#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

[InitializeOnLoad]
public class UDPExecuteEditor : EditorWindow
{
    static public int port = 8193;

    public class RemoteCmd
    {
        public int Tp;
        public string Cmd;
    }
    static List<RemoteCmd> CommandsQ = new List<RemoteCmd>();

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

        Debug.Log("Executing:" + CommandsQ[0].Cmd);

        if (CommandsQ[0].Tp == 0)
        {
            EditorApplication.ExecuteMenuItem(CommandsQ[0].Cmd);
        }
        else if (CommandsQ[0].Tp == 1)
        {
            EditorChangeLayout.LoadLayout(CommandsQ[0].Cmd);
        }

        CommandsQ.RemoveAt(0);

    }

    static public void RecvData(byte[] buffer)
    {
        LastRecvTime = DateTime.Now;

        MemoryStream mstr = new MemoryStream(buffer);
        using (var br = new BinaryReader(mstr))
        {
            int tp = br.ReadByte();
            int len = br.ReadInt32();
            if(buffer.Length < len+5)
            {
                Debug.LogWarning($"UDPExecuteEditor getting wrong data {tp}, {len}");
                return;
            }

            var recvCmd = System.Text.Encoding.UTF8.GetString(buffer, 5, len);
            lock (CommandsQ)
            {
                CommandsQ.Add(new RemoteCmd() { Tp = tp, Cmd = recvCmd });
            }
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