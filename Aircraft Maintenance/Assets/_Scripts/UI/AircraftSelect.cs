using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AircraftUILoading))]
public class AircraftSelect : MonoBehaviour
{
    public Button nextButton;
    public Button previousButton;

    public Button ModelOne;

    public Canvas ModelOneParts;

    private AircraftUILoading AUIL;

    void Start()
    {
        AUIL = GetComponent<AircraftUILoading>();
    }

    private void OnEnable()
    {
        //AUIL.loadViews("");
    }

    //Goes to next model
    public void Next()
    {
        int model = AUIL.CheckLoop(AUIL.currentModel + 1);
        if (model != AUIL.currentModel)
        {
            AUIL.loadViews2(model);
        }
    }

    //Goes to previous model
    public void Previous()
    {
        int model = AUIL.CheckLoop(AUIL.currentModel - 1);
        if (model != AUIL.currentModel)
        {
            AUIL.loadViews2(model);
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
