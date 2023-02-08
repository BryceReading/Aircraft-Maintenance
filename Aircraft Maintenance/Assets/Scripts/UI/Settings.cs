using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Slider mouseSensitivity;
    public Slider soundVolume;

    public TMP_Text mouseText;
    public TMP_Text soundText;
    public TMP_Text helpText;

    public Button desktopMouse;
    public Button desktopFPS;
    public Button VRButton;

    public int s_movement;
    public float s_sensitivty;
    public float s_sound;
    public DesktopCamLooking desktopCamLooking;

    public Canvas RemoveModels;

    CameraChange cameraChange;
    ModeSwitch modeSwitch;

    //Scale the mouse sensitivity
    public void MouseSensitivity()
    {
        s_sensitivty = (mouseSensitivity.value - 80.0f) / 2;
        desktopCamLooking.Sense = mouseSensitivity.value;
        mouseText.text = s_sensitivty.ToString();
    }

    //Scale the sound volume
    public void SoundVolume()
    {
        soundText.text = soundVolume.value.ToString();
        s_sound = soundVolume.value / 100;
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

