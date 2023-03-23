using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Now not a weapon switching script but instead a WeaponSwap script 
/// 
/// </summary>

public class WeaponSwap : MonoBehaviour
{
    GameObject tablet;
    public Animator animator;

    public bool active;

    public UI ui;

    // Start is called before the first frame update
    void Start()
    {
        tablet = GameObject.Find("Tablet3");
        animator = tablet.GetComponent<Animator>();
        active = false;
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Open();
        }
    }

    public void Open()
    {
        if (active == false)
        {
            animator.SetTrigger("Raise Tablet");
            active = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else if (active == true)
        {
            animator.SetTrigger("Lower Tablet");
            active = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
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

if (tablet.gameObject.activeInHierarchy)
        {
            //tablet.SetActive(false);
            animator.SetTrigger("Lower Tablet");
        }
        else
        {
           // tablet.SetActive(true);
            animator.SetTrigger("Raise Tablet");
        }
*
*/