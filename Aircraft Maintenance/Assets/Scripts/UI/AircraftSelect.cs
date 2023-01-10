using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AircraftSelect : MonoBehaviour
{
    public Button nextButton;
    public Button previousButton;

    public Button ModelOne;
    public Button ModelTwo;

    public Canvas ModelOneParts;
    public Canvas ModelTwoParts;

    int page = 0;

    void Start()
    {
        ModelTwo.gameObject.SetActive(false);
    }

    //Goes to next model
    public void Next()
    {
        if (page == 0)
        {
            ModelOne.gameObject.SetActive(false);
            ModelTwo.gameObject.SetActive(true);

            ModelOneParts.enabled = false;
            ModelTwoParts.enabled = true;
        }
        if(page == 1)
        {
            ModelOne.gameObject.SetActive(true);
            ModelTwo.gameObject.SetActive(false);

            ModelOneParts.enabled = true;
            ModelTwoParts.enabled = false;
        }

        if(page < 1)
        {
            page++;
        }
        else
        {
            page--;
        }
    }

    //Goes to previous model
    public void Previous()
    {
        if(page == 1)
        {
            ModelOne.gameObject.SetActive(true);
            ModelTwo.gameObject.SetActive(false);

            ModelOneParts.enabled = true;
            ModelTwoParts.enabled = false;
        }
        
        if(page == 0)
        {
            ModelOne.gameObject.SetActive(false);
            ModelTwo.gameObject.SetActive(true);

            ModelOneParts.enabled = false;
            ModelTwoParts.enabled = true;
        }

        if (page < 1)
        {
            page++;
        }
        else
        {
            page--;
        }
    }
}


//public class AircraftSelect : MonoBehaviour
//{
//    System.IO.DirectoryInfo dir;

//    string v_path;
//    string[] v_modelArray;

//    int v_modelAmount;
//    int v_page;

//    public Button nextButton;
//    public Button previousButton;

//    public Button modelButton;
//    public Button modelButtonClone;

//    public GameObject aircraftSelect;
//    void Start()
//    {
//        v_modelArray = new string[5];
//        v_modelArray[0] = "Cockpit";
//        v_modelArray[1] = "Drop Door";
//        v_modelArray[2] = "Main Door";
//        v_modelArray[3] = "Rotor Engine";
//        v_modelArray[4] = "Tail";

//        v_path = Application.dataPath;

//        //Count how many models are in the model folder
//        //Check if there is the same amount of models in the different model folders

//        for (int x = 0; x < 5; x++)
//        {
//            dir = new System.IO.DirectoryInfo(v_path + "/Models/" + v_modelArray[x]);
//            if ((x >= 1) && ((dir.GetFiles().Length / 2) != v_modelAmount))
//            {
//                Debug.Log("There is a different amount of models in the folders");
//            }
//            v_modelAmount = dir.GetFiles().Length;
//            v_modelAmount = v_modelAmount / 2;
//            Debug.Log(v_modelAmount);
//        }

//        if (v_modelAmount >= 2)
//        {
//            nextButton.gameObject.SetActive(true);
//            previousButton.gameObject.SetActive(true);
//        }
//        else
//        {
//            nextButton.gameObject.SetActive(false);
//            previousButton.gameObject.SetActive(false);
//        }

//        for (int x = 0; x < v_modelAmount; x++)
//        {
//            modelButtonClone = Instantiate(modelButton, new Vector3(450, 250, 0), Quaternion.identity);
//            modelButtonClone.transform.SetParent(aircraftSelect.transform);

//            if (x == 0)
//            {
//                modelButtonClone.gameObject.SetActive(true);
//                Debug.Log(x);
//            }
//        }
//    }
//}
