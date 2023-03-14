using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Canvas menu;
    public Canvas settings;
    public Canvas help;
    public Canvas aircraftSelect;
    public Canvas toolTip;

    public bool globalEnabled = false;
    public WeaponSwap weaponSwap;
    [SerializeField]
    public bool paused = false;

    void Update()
    {
        //Gets menu up
        if (paused == false && Input.GetKeyDown(KeyCode.Escape))
        {
            globalEnabled = true;
            menu.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            paused = true;
            toolTip.enabled = false;
        }
        else if(paused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    //Menu closes
    public void Resume()
    {
        globalEnabled = false;
        menu.enabled = false;
        if (weaponSwap.active == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            toolTip.enabled = true;
        }
        paused = false;
    }

    //Goes to settings
    public void SettingsMenu()
    {
        menu.enabled = false;
        settings.enabled = true;
    }

    //Goes to the help menu
    public void HelpMenu()
    {
        menu.enabled = false;
        help.enabled = true;
    }

    //Goes to Aircraft Select
    public void AircraftSelect()
    {
        menu.enabled = false;
        aircraftSelect.enabled = true;
    }

    //Goes back, should go back to the menu
    public void Back()
    {
        help.enabled = false;
        settings.enabled = false;
        aircraftSelect.enabled = false;
        
        menu.enabled = true;
    }

    //Quits the application
    public void Quit()
    {
        Application.Quit();
    }
}
