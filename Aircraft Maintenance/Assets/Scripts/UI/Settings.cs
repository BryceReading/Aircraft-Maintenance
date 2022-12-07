using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider mouseSensitivity;
    public Slider soundVolume;

    public Text mouseText;
    public Text soundText;
    public Text helpText;

    public Button desktopMouse;
    public Button desktopFPS;
    public Button VRButton;

    public int s_movement = 0;

    public DesktopCamLooking desktopCamLooking;

    //Scale the mouse sensitivity
    public void MouseSensitivity()
    {
        desktopCamLooking.Sense = mouseSensitivity.value;
        mouseText.text = mouseSensitivity.value.ToString();
    }

    //Scale the sound volume
    public void SoundVolume()
    {
        soundText.text = soundVolume.value.ToString();
    }
    
    //Change to Desktop Mouse controls
    public void DesktopMouse()
    {
        if(s_movement == 1)
        {
            desktopFPS.image.fillCenter = true;
        }
        else if(s_movement == 2)
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
        if(s_movement == 0)
        {
            desktopMouse.image.fillCenter = true;
        }
        else if(s_movement == 2)
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
        if(s_movement == 0)
        {
            desktopMouse.image.fillCenter = true;
        }
        else if(s_movement == 1)
        {
            desktopFPS.image.fillCenter = true;
        }
        
        helpText.text = "VR Controls";

        s_movement = 2;
        VRButton.image.fillCenter = false;
    }
}