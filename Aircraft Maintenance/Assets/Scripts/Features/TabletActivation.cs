  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Now not a weapon switching script but instead a WeaponSwap script 
/// WeaponSwap
/// </summary>

public class TabletActivation : MonoBehaviour
{
    public GameObject tablet;

    // Start is called before the first frame update
    void Start()
    {
        tablet = GameObject.Find("Tablet");
        tablet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Open();
        }
    }

    void Open()
    {
        if (tablet.gameObject.activeInHierarchy)
        {
            tablet.SetActive(false);
        }
        else
        {
            tablet.SetActive(true);
        }
    }
}

/*
 *     
    public int currentSlected = 0;

    // Start is called before the first frame update
    void Start()
    {
        Select();
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelected = currentSlected;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentSlected >= transform.childCount - 1) { currentSlected = 0; }
            else { currentSlected++; }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentSlected <= 0) { currentSlected = transform.childCount - 1; }
            else { currentSlected--; }
        }
        if (previousSelected != currentSlected)
        {
            Select();
        }
    }

    void Select()
    {
        int i = 0;
        foreach (Transform tool in transform)
        {
            if (i == currentSlected) { tool.gameObject.SetActive(true); }
            else { tool.gameObject.SetActive(false); }
            i++;
        }
    }
*
*/