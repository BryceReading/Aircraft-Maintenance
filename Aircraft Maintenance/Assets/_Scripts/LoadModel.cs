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
    GameObject currentActive; //Cockpit, DropDoor, MainDoor, RotorEngine, Tail, Frame
    public List<string> modelList = new List<string>();

    public RemoveModels tablet;

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

        if(modelList.Contains("AW101"))
        {
            loadViewModel("AW101");
        }
        
        /////ERROR CHECKING
                                                              /*foreach(string s in modelList)
                                                                {
                                                                    GameObject check = Resources.Load<GameObject>(v_path + s) as GameObject;
                                                                    if(check.transform.childCount != nameOf.Length || Array.IndexOf(nameOf, s) < 0)
                                                                    {
                                                                        modelList.Remove(s);
                                                                    }
                                                                }*/

    }

    public GameObject loadViewModel(string modelName, Vector3 location)
    {
        GameObject loadModel = Resources.Load<GameObject>("Aircraft/" + modelName);
        currentActive = Instantiate(loadModel, location, Quaternion.identity);
        SetTablet();
        currentActive.tag = "Model";
        return currentActive;
    }

    public GameObject loadViewModel(string modelName)
    {
        GameObject loadModel = Resources.Load<GameObject>("Aircraft/" + modelName);
        GameObject temp = Instantiate(loadModel, Vector3.zero, Quaternion.identity);
        List<Transform> children = temp.transform.GetComponentsInChildren<Transform>().ToList<Transform>();
        children.RemoveAt(0);
        Vector3 extents = Vector3.zero;
        foreach (Transform child in children)
        {
            Vector3 abs = new Vector3(Mathf.Abs(child.transform.localPosition.x), Mathf.Abs(child.transform.localPosition.y), Mathf.Abs(child.transform.localPosition.z));
            Vector3 t = child.gameObject.transform.localPosition + child.gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.extents;
            extents.y = t.y > extents.y ? t.y : extents.y;
        }

        Vector3 move = extents/2; 
        temp.transform.position += move;
        currentActive = temp;
        SetTablet();
        currentActive.tag = "Model";
        return currentActive;
    }

    private void SetTablet()
    {
        Transform temp = currentActive.transform.Find("Cockpit");
        tablet.Cockpit = temp != null ? temp.gameObject : null;

        temp = currentActive.transform.Find("MainDoor");
        tablet.MainDoor = temp != null ? temp.gameObject : null;

        temp = currentActive.transform.Find("DropDoor");
        tablet.DropDoor = temp != null ? temp.gameObject : null;

        temp = currentActive.transform.Find("RotorEngine");
        tablet.RotorEngine = temp != null ? temp.gameObject : null;

        temp = currentActive.transform.Find("Tail");
        tablet.Tail = temp != null ? temp.gameObject : null;

        tablet.CheckList();
    }

    public void swapModel(string modelName)
    {
        int childCount = currentActive.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(currentActive.transform.GetChild(i).gameObject);
        }
        Destroy(currentActive);
        currentActive = null;

        loadViewModel(modelName);

    }
}
