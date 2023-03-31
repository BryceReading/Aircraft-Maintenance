


 #if UNITY_EDITOR
 using UnityEditor;
 using System.IO;
 using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using System;

/*class GetFilesBeforeBuild : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }
    Queue<GameObject[]> files = new Queue<GameObject[]>();
    public void OnPreprocessBuild(BuildReport report)
    {
        files.Enqueue(Resources.LoadAll<GameObject>("Cockpit"));
        files.Enqueue(Resources.LoadAll<GameObject>("DropDoor"));
        files.Enqueue(Resources.LoadAll<GameObject>("MainDoor"));
        files.Enqueue(Resources.LoadAll<GameObject>("RotorEngine"));
        files.Enqueue(Resources.LoadAll<GameObject>("Tail"));
        files.Enqueue(Resources.LoadAll<GameObject>("Skeleton"));

    }
}*/


class CreateFolderOnBuild : IPostprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }
    public void OnPostprocessBuild(BuildReport report)
    {
        string[] splitPath = report.summary.outputPath.Split('.');
        splitPath[report.summary.outputPath.Split('.').Length - 1] = "_Data";
        for (int i = 1; i<splitPath.Length; i++)
        {
            splitPath[0] += splitPath[i];
        }

        string resourcesFolder = Path.Combine(splitPath[0], "Resources");
        string editorPath = Application.dataPath + "/Resources/";
        if (Directory.Exists(editorPath))
        {
            string newFolder = Path.Combine(resourcesFolder, "Cockpit/");
            string[] files = Directory.GetFiles(editorPath+"Cockpit");
            Directory.CreateDirectory(newFolder);
            foreach (string s in files) 
            {
                if (s.Split('.')[s.Split('.').Length - 1] != "meta")
                {
                    File.Copy(s, newFolder + Path.GetFileName(s), true);
                }
            }

            newFolder = Path.Combine(resourcesFolder, "DropDoor/");
            files = Directory.GetFiles(editorPath + "DropDoor");
            Directory.CreateDirectory(newFolder);
            foreach (string s in files)
            {
                if (s.Split('.')[s.Split('.').Length - 1] != "meta")
                {
                    File.Copy(s, newFolder + Path.GetFileName(s), true);
                }
            }

            newFolder = Path.Combine(resourcesFolder, "MainDoor/");
            files = Directory.GetFiles(editorPath + "MainDoor");
            Directory.CreateDirectory(newFolder);
            foreach (string s in files)
            {
                if (s.Split('.')[s.Split('.').Length - 1] != "meta")
                {
                    File.Copy(s, newFolder + Path.GetFileName(s), true);
                }
            }

            newFolder = Path.Combine(resourcesFolder, "RotorEngine/");
            files = Directory.GetFiles(editorPath + "RotorEngine");
            Directory.CreateDirectory(newFolder);
            foreach (string s in files)
            {
                if (s.Split('.')[s.Split('.').Length - 1] != "meta")
                {
                    File.Copy(s, newFolder + Path.GetFileName(s), true);
                }
            }

            newFolder = Path.Combine(resourcesFolder, "Tail/");
            files = Directory.GetFiles(editorPath + "Tail");
            Directory.CreateDirectory(newFolder);
            foreach (string s in files)
            {
                if (s.Split('.')[s.Split('.').Length - 1] != "meta")
                {
                    File.Copy(s, newFolder + Path.GetFileName(s), true);
                }
            }

            newFolder = Path.Combine(resourcesFolder, "Skeleton/");
            files = Directory.GetFiles(editorPath + "Skeleton");
            Directory.CreateDirectory(newFolder);
            foreach (string s in files)
            {
                if (s.Split('.')[s.Split('.').Length - 1] != "meta")
                {
                    File.Copy(s, newFolder + Path.GetFileName(s), true);
                }
            }
        }
    }
}
#endif