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

    bool paused = false;

    void Update()
    {
        //Gets menu up
        if (paused == false && Input.GetKeyDown(KeyCode.Escape))
        {
            menu.enabled = true;
            Time.timeScale = 0;
            paused = true;
        }
    }

    //Menu closes
    public void Resume()
    {
        menu.enabled = false;
        Time.timeScale = 1;
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

    //Goes to the SampleScene
    public void SampleScene()
    {
        SceneManager.LoadScene("SampleScene");
        aircraftSelect.enabled = false;
        Time.timeScale = 1;
        paused = false;
    }

    //Goes back, should go back to the menu
    public void Back()
    {
        if(help.enabled == true)
        {
            help.enabled = false;
        }
        else if(settings.enabled == true)
        {
            settings.enabled = false;
        }
        else if(aircraftSelect.enabled == true)
        {
            aircraftSelect.enabled = false;
        }

        menu.enabled = true;
    }

    //Quits the application
    public void Quit()
    {
        Application.Quit();
    }
}
