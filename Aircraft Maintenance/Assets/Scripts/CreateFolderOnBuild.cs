


 #if UNITY_EDITOR
 using UnityEditor;
 using System.IO;
 using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.Diagnostics;
using UnityEngine.UI;

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

        //pathToBuiltProject += "_Data";
        Debug.Print(splitPath[0]);
        // Create the new folder in the Resources folder
        string resourcesFolder = Path.Combine(splitPath[0], "Resources");
        string newFolder = Path.Combine(resourcesFolder, "Cockpit");
        Directory.CreateDirectory(newFolder);
        newFolder = Path.Combine(resourcesFolder, "DropDoor");
        Directory.CreateDirectory(newFolder);
        newFolder = Path.Combine(resourcesFolder, "MainDoor"); 
        Directory.CreateDirectory(newFolder);
        newFolder = Path.Combine(resourcesFolder, "RotorEngine");
        Directory.CreateDirectory(newFolder);
        newFolder = Path.Combine(resourcesFolder, "Tail");
        Directory.CreateDirectory(newFolder);

    }
}
#endif