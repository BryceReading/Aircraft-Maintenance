using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Slider mouseSensitivityFPS;
    public Slider mouseSensitivityFixed;
    public Slider soundVolumeFPS;
    public Slider soundVolumeFixed;

    public Text mouseTextFPS;
    public Text mouseTextFixed;
    public Text soundTextFPS;
    public Text soundTextFixed;
    public Text helpText;

    public Button desktopMouse;
    public Button desktopFPS;
    public Button VRButton;

    public int s_movement;
    public float s_sensitivty;
    public float s_sound;
    public DesktopCamLooking desktopCamLooking;

    public Canvas RemoveModels;
    public Canvas FPSSettings;
    public Canvas FixedSettings;

    //Scale the mouse sensitivity
    public void MouseSensitivity()
    {        
        if (FPSSettings.enabled == true)
        {
            desktopCamLooking.Sense = mouseSensitivityFPS.value;
            mouseSensitivityFixed.value = mouseSensitivityFPS.value;
        }
        else if (FixedSettings.enabled == true)
        {
            desktopCamLooking.Sense = mouseSensitivityFixed.value;
            mouseSensitivityFPS.value = mouseSensitivityFixed.value;
        }
        s_sensitivty = mouseSensitivityFPS.value - 80.0f;
        mouseTextFPS.text = s_sensitivty.ToString();
        mouseTextFixed.text = s_sensitivty.ToString();
    }

    //Scale the sound volume
    //Attach AudioSource to the object and use s_sound to for the volume
    public void SoundVolume()
    {
        //Need to connect both volume settings
        if (FPSSettings.enabled == true)
        {
            soundVolumeFixed.value = soundVolumeFPS.value;
            soundTextFPS.text = soundVolumeFPS.value.ToString();
            soundTextFixed.text = soundVolumeFixed.value.ToString();
        }
        else if(FixedSettings.enabled == true)
        {
            soundVolumeFPS.value = soundVolumeFixed.value;
            soundTextFPS.text = soundVolumeFPS.value.ToString();
            soundTextFixed.text = soundVolumeFixed.value.ToString();
        }


        s_sound = soundVolumeFPS.value / 100;
        Debug.Log(s_sound);
    }

    //Change to Desktop Mouse controls
    public void DesktopMouse()
    {
        if (s_movement == 1)
        {
            desktopFPS.image.fillCenter = true;
        }
        else if (s_movement == 2)
        {
            VRButton.image.fillCenter = true;
        }

        helpText.text = "Mouse Controls";

        s_movement = 0;
        desktopMouse.image.fillCenter = false;
    }

    //Change to Desktop Mouse controls
    public void DesktopFPS()
    {
        if (s_movement == 0)
        {
            desktopMouse.image.fillCenter = true;
        }
        else if (s_movement == 2)
        {
            VRButton.image.fillCenter = true;
        }

        helpText.text = "FPS Controls";

        s_movement = 1;
        desktopFPS.image.fillCenter = false;
    }

    //Change to VR controls
    public void VR()
    {
        if (s_movement == 0)
        {
            desktopMouse.image.fillCenter = true;
        }
        else if (s_movement == 1)
        {
            desktopFPS.image.fillCenter = true;
        }

        helpText.text = "VR Controls";

        s_movement = 2;
        VRButton.image.fillCenter = false;
    }
}

