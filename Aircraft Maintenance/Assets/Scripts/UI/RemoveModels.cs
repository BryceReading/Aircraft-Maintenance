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
        CockpitButton.image.fillCenter = cockpitBool;
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

        DropDoorButton.image.fillCenter = dropDoorBool;
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

        MainDoorButton.image.fillCenter = mainDoorBool;
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
        RotorEngineButton.image.fillCenter = rotorEngineBool;
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
        TailButton.image.fillCenter = tailBool;
        Tail.gameObject.SetActive(tailBool);
    }
}
