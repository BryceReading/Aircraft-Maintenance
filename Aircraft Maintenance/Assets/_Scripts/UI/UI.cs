using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Canvas menuCanvas;
    public Canvas settingsCanvas;
    public Canvas helpCanvas;
    public Canvas aircraftSelectCanvas;

    public bool globalEnabled = false;
    public WeaponSwap weaponSwap;
    public Settings settings;
    public FixedCamMovement fixedCamMovement;
    public DesktopCamLooking desktopCamLooking;

    [SerializeField]
    public bool paused = false;

    void Update()
    {
        //Gets menu up
        if (paused == false && Input.GetKeyDown(KeyCode.Escape))
        {
            globalEnabled = true;
            menuCanvas.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            paused = true;
        }
        else if(paused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
            aircraftSelectCanvas.enabled = false;
            helpCanvas.enabled = false;
            settingsCanvas.enabled = false;
            if (settings.s_camera == false)
            {
                settings.s_sensitivty = settings.mouseSensitivity.value * 50f + 40f;
                fixedCamMovement.FC_speed = settings.s_sensitivty;
            }
            else
            {
                settings.s_sensitivty = settings.mouseSensitivity.value * 500f + 40f;
                desktopCamLooking.Sense = settings.mouseSensitivity.value;
            }
        }
    }

    //Menu closes
    public void Resume()
    {
        globalEnabled = false;
        menuCanvas.enabled = false;
        if (weaponSwap.active == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
        paused = false;
        if (settings.s_camera == false)
        {
            settings.s_sensitivty = settings.mouseSensitivity.value * 50f + 40f;
            fixedCamMovement.FC_speed = settings.s_sensitivty;
        }
        else
        {
            settings.s_sensitivty = settings.mouseSensitivity.value * 500f + 40f;
            desktopCamLooking.Sense = settings.mouseSensitivity.value;
        }
    }

    //Goes to settings
    public void SettingsMenu()
    {
        menuCanvas.enabled = false;
        settingsCanvas.enabled = true;
    }

    //Goes to the help menu
    public void HelpMenu()
    {
        menuCanvas.enabled = false;
        helpCanvas.enabled = true;
    }

    //Goes to Aircraft Select
    public void AircraftSelect()
    {
        menuCanvas.enabled = false;
        aircraftSelectCanvas.enabled = true;
    }

    //Goes back, should go back to the menu
    public void Back()
    {
        helpCanvas.enabled = false;
        settingsCanvas.enabled = false;
        aircraftSelectCanvas.enabled = false;
        
        menuCanvas.enabled = true;
    }

    //Quits the application
    public void Quit()
    {
        Application.Quit();
    }
}
