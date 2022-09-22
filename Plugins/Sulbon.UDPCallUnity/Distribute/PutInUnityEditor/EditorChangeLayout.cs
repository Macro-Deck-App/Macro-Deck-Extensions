#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Reflection;
using Type = System.Type;

//https://answers.unity.com/questions/382973/programmatically-change-editor-layout.html
public static class EditorChangeLayout
{
    private enum MethodType { Save, Load };

    static MethodInfo GetMethod(MethodType method_type)
    {

        Type layout = Type.GetType("UnityEditor.WindowLayout,UnityEditor");

        MethodInfo save = null;
        MethodInfo load = null;

        if (layout != null)
        {
            load = layout.GetMethod("LoadWindowLayout", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(string), typeof(bool) }, null);
            save = layout.GetMethod("SaveWindowLayout", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(string) }, null);
        }

        if (method_type == MethodType.Save)
        {
            return save;
        }
        else
        {
            return load;
        }
    }

    public static void SaveLayout(string file)
    {
        var dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Unity\\Editor-5.x\\Preferences\\Layouts\\default\\";
        var fullpath = Path.Combine(dir, file);
        if (fullpath.EndsWith(".wlt") == false)
        {
            fullpath = fullpath + ".wlt";
        }

        if (System.IO.File.Exists(fullpath) == false)
        {
            Debug.LogError($"no file found: {fullpath}");
            return;
        }

        GetMethod(MethodType.Save).Invoke(null, new object[] { fullpath });
    }

    public static void LoadLayout(string file)
    {
        var dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Unity\\Editor-5.x\\Preferences\\Layouts\\default\\";
        var fullpath = Path.Combine(dir, file);
        if (fullpath.EndsWith(".wlt") == false)
        {
            fullpath = fullpath + ".wlt";
        }

        if (System.IO.File.Exists(fullpath) == false)
        {
            Debug.LogError($"no file found: {fullpath}");
            return;
        }
        GetMethod(MethodType.Load).Invoke(null, new object[] { fullpath, false });
    }

}

#endif