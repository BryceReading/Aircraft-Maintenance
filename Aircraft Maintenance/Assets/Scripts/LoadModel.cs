using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class LoadModel : MonoBehaviour
{
    const int size = 6;

    string v_path;
    [HideInInspector]
    public string[] nameOf = new string[size] {"Cockpit", "DropDoor", "MainDoor", "RotorEngine", "Tail", "Frame" }; //When you figure out the skeleton Loading, add in a skeleton here
    List<string>[] v_objList = new List<string>[size]; //Cockpit, DropDoor, MainDoor, RotorEngine, Tail, Frame
    GameObject[] currentActive = new GameObject[size]; //Cockpit, DropDoor, MainDoor, RotorEngine, Tail, Frame
    public List<string> modelList = new List<string>();

    private void Start()
    {
        v_path = (Application.dataPath + "/Resources/Aircraft/");
        string[] temp = Directory.GetFiles(v_path, "*.fbx");
        for(int i =0; i< temp.Length; i++)
        {
            temp[i] = Path.GetFileName(temp[i]);
            temp[i] = temp[i].Split('.')[0];
        }
        modelList.AddRange(temp);
        
        /////ERROR CHECKING
        /*                                                        foreach(string s in modelList)
                                                                {
                                                                    GameObject check = Resources.Load<GameObject>(v_path + s) as GameObject;
                                                                    if(check.transform.childCount != nameOf.Length || Array.IndexOf(nameOf, s) < 0)
                                                                    {
                                                                        modelList.Remove(s);
                                                                    }
                                                                }*/

    }

    public GameObject loadViewModel(string modelName, int region, Vector3 location)
    {
        GameObject loadModel = Resources.Load<GameObject>(nameOf[region] + "/" + modelName + "." + nameOf[region]);
        return Instantiate(loadModel, location, Quaternion.identity);
    }

    public void swapModel(string modelName)
    {
        for (int i = 0; i < currentActive.Count(); i++)
        {
            Destroy(currentActive[i]);
            currentActive[i] = null;
        }      

        GameObject Cockpit = Resources.Load<GameObject>(nameOf[0] + "/" + modelName + "." + nameOf[0]);
        GameObject DropDoor = Resources.Load<GameObject>(nameOf[1] + "/" + modelName + "." + nameOf[1]);
        GameObject MainDoor = Resources.Load<GameObject>(nameOf[2] + "/" + modelName + "." + nameOf[2]);
        GameObject RotorEngine = Resources.Load<GameObject>(nameOf[3] + "/" + modelName + "." + nameOf[3]);
        GameObject Tail = Resources.Load<GameObject>(nameOf[4] + "/" + modelName + "." + nameOf[4]);


        currentActive[0] = Instantiate(Cockpit, Vector3.zero, Quaternion.identity);
        currentActive[1] = Instantiate(DropDoor, Vector3.zero, Quaternion.identity);
        currentActive[2] = Instantiate(MainDoor, Vector3.zero, Quaternion.identity);
        currentActive[3] = Instantiate(RotorEngine, Vector3.zero, Quaternion.identity);
        currentActive[4] = Instantiate(Tail, Vector3.zero, Quaternion.identity);

    }
}
