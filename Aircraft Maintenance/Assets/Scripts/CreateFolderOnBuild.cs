


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
            string[] files = Directory.GetFiles(editorPath + "Aircraft");
            string newFolder = Path.Combine(resourcesFolder, "Aircraft/");
            Directory.CreateDirectory(newFolder);
            foreach (string s in files)
            {
                if (s.Split('.')[s.Split('.').Length - 1] != "meta")
                {
                    File.Copy(s, newFolder + Path.GetFileName(s), true);
                }
            }
            File.Copy(Path.Combine(editorPath + "README.txt"), newFolder + "README.txt", true);
        }
    }
}
#endif