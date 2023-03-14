using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveModels : MonoBehaviour
{
    public Button CockpitButton;
    public Button DropDoorButton;
    public Button MainDoorButton;
    public Button RotorEngineButton;
    public Button TailButton;

    public GameObject Cockpit;
    public GameObject DropDoor;
    public GameObject MainDoor;
    public GameObject RotorEngine;
    public GameObject Tail;

    public bool cockpitBool = true;
    public bool dropDoorBool = true;
    public bool mainDoorBool = true;
    public bool rotorEngineBool = true;
    public bool tailBool = true;


    //Removes/Adds Cockpit to scene
    public void RemoveCockpit()
    {
        if (cockpitBool == true)
        {
            cockpitBool = false;
        }
        else
        {
            cockpitBool = true;
        }
        Cockpit.gameObject.SetActive(cockpitBool);

    }

    //Removes/Adds Drop Door to scene
    public void RemoveDropDoor()
    {
        if(dropDoorBool == true)
        {
            dropDoorBool = false;
        }
        else
        {
            dropDoorBool = true;
        }
        DropDoor.gameObject.SetActive(dropDoorBool);
    }

    //Removes/Adds Main Door to scene
    public void RemoveMainDoor()
    {
        if(mainDoorBool == true)
        {
            mainDoorBool = false;
        }
        else
        {
            mainDoorBool = true;
        }
        MainDoor.gameObject.SetActive(mainDoorBool);
    }

    //Removes/Adds Rotor Engine to scene
    public void RemoveRotorEngine()
    {
        if(rotorEngineBool == true)
        {
            rotorEngineBool = false;
        }
        else
        {
            rotorEngineBool = true;
        }
        RotorEngine.gameObject.SetActive(rotorEngineBool);
    }
    
    //Removes/Adds Tail to scene
    public void RemoveTail()
    {
        if(tailBool == true)
        {
            tailBool = false;
        }
        else
        {
            tailBool = true;
        }
        Tail.gameObject.SetActive(tailBool);
    }
}