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

    public GameObject FixedCamera;
    public GameObject FPSCamera;

    public Transform Fixed_transform;
    public Transform FPS_transform;

    public Canvas Menu;
    public Canvas SettingsMenu;
    public Canvas AircraftSelect;
    public Canvas Help;

    CameraChange cameraChange;
    ModeSwitch modeSwitch;
    public void Start()
    {
        s_sound = 0.5f;
    }

    //Scale the mouse sensitivity
    public void MouseSensitivity()
    {
        s_sensitivty = (mouseSensitivity.value - 40.0f) / 500f;
        desktopCamLooking.Sense = mouseSensitivity.value;
        mouseText.text = ((int)s_sensitivty).ToString();
    }

    //Scale the sound volume
    public void SoundVolume()
    {
        soundText.text = soundVolume.value.ToString();
        s_sound = soundVolume.value / 100;
    }

    //Change to Desktop Mouse controls
    public void DesktopFixed()
    {
        FixedCamera.gameObject.SetActive(true);
        FPSCamera.gameObject.SetActive(false);

        helpText.text = "Fixed Controls";

        desktopFPS.image.fillCenter = true;
        VRButton.image.fillCenter = true;
        desktopMouse.image.fillCenter = false;

        Menu.transform.SetParent(Fixed_transform);
        SettingsMenu.transform.SetParent(Fixed_transform);
        AircraftSelect.transform.SetParent(Fixed_transform);
        Help.transform.SetParent(Fixed_transform);

        
    }

    //Change to Desktop Mouse controls
    public void DesktopFPS()
    {
        FixedCamera.gameObject.SetActive(false);
        FPSCamera.gameObject.SetActive(true);

        helpText.text = "FPS Controls\n" +
            "W- Forwards\n" +
            "A- Left\n" +
            "S- Backwards\n" +
            "D- Right\n" +
            "Mouse- Looking around\n" +
            "Escape- Pause/Unpause\n" +
            "E- Raise/Lower Tablet";

        desktopFPS.image.fillCenter = false;
        VRButton.image.fillCenter = true;
        desktopMouse.image.fillCenter = true;

        Menu.transform.SetParent(FPS_transform);
        SettingsMenu.transform.SetParent(FPS_transform);
        AircraftSelect.transform.SetParent(FPS_transform);
        Help.transform.SetParent(FPS_transform);

        Cursor.lockState = CursorLockMode.None;
    }

    //Change to VR controls
    public void VR()
    {
        desktopMouse.image.fillCenter = true;
        desktopFPS.image.fillCenter = true;
        
        helpText.text = "VR Controls";

        s_movement = 2;
        VRButton.image.fillCenter = false;
    }
}

