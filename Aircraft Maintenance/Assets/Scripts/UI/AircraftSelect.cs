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
