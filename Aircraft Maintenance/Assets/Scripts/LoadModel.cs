using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class LoadModel : MonoBehaviour
{
    const int size = 5;

    string v_path;
    [HideInInspector]
    public string[] nameOf = new string[size] {"Cockpit", "DropDoor", "MainDoor", "RotorEngine", "Tail" }; //When you figure out the skeleton Loading, add in a skeleton here
    List<string>[] v_objList = new List<string>[size]; //Cockpit, DropDoor, MainDoor, RotorEngine, Tail
    GameObject[] currentActive = new GameObject[size]; //Cockpit, DropDoor, MainDoor, RotorEngine, Tail
    public List<string> modelList = new List<string>();

    //public GameObject aircraftSelect;
    void Start()
    {
        v_path = (Application.dataPath + "/Resources");

        for (int i = 0; i< v_objList.Length; i++) { v_objList[i] = new List<string>(); } //Initialises the lists of .fbx available


        for(int s = 0; s< v_objList.Length; s++) //Stores the names of all of the models in their respecive directories
        {
            string[] temp = Directory.GetFiles(v_path + "/" + nameOf[s], "*.fbx");
            for (int i = 0;i < temp.Length; i++) { temp[i] = Path.GetFileName(temp[i]); }

            foreach (string r in temp) {
                if (s > 0)
                {
                    foreach (string e in v_objList[0])
                    {
                        if (e.Split('.')[0] == r.Split('.')[0] && (r.Split('.')[1] == nameOf[s]))
                        {
                            v_objList[s].Add(Path.GetFileName(r));
                            break;
                        }
                    }
                }
                else if (r.Split('.')[1] == nameOf[s])
                { 
                    v_objList[s].Add(Path.GetFileName(r));
                }
            }
        }

        List<string> temp2 = v_objList[0];
        foreach (string p in temp2) //Clears out any models which do not exist in all directories
        {
            int x = 0;
            for (int i = 1; i < v_objList.Length; i++)
            {
                x+=Convert.ToInt16(v_objList[i].Find(q => q.Split('.')[0] == p.Split('.')[0]) != null);
            }
            if (x != v_objList.Length - 1)
            {
                for (int i = 0; i < v_objList.Length; i++)
                {
                    try { v_objList[i].RemoveAt(v_objList[i].FindIndex(q => q.Split('.')[0] == p.Split('.')[0])); }
                    catch { }
                }
            }
            else
            {
                modelList.Add(p.Split('.')[0]);
            }
        }
        //swapModel(modelList[0]);
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
