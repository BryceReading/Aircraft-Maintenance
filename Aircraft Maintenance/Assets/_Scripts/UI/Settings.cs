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

    public int s_movement;
    public float s_sensitivty;
    public float s_sound;
    public bool s_camera;

    public DesktopCamLooking desktopCamLooking;
    public FixedCamMovement fixedCamMovement;

    public Canvas RemoveModels;

    public GameObject FixedCamera;
    public GameObject FPSCamera;

    public Transform Fixed_transform;
    public Transform FPS_transform;

    public Canvas Menu;
    public Canvas SettingsMenu;
    public Canvas AircraftSelect;
    public Canvas Help;

    public WeaponSwap weaponSwap;

    public void Start()
    {
        s_sound = 0.5f;
        s_camera = true;

        s_sensitivty = (mouseSensitivity.value * 500f) + 40f;
    }

    //Scale the mouse sensitivity
    public void MouseSensitivity()
    {
        if(s_camera == true)
        {
            s_sensitivty = (mouseSensitivity.value * 500f) + 40f;
            desktopCamLooking.Sense = s_sensitivty;
        }
        else
        {
            s_sensitivty = mouseSensitivity.value * 50f + 40f;
            fixedCamMovement.FC_speed = s_sensitivty;
        }
        mouseText.text = mouseSensitivity.value.ToString();
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

        helpText.text = "Fixed Controls\n" +
            "Left Click and move mouse- Look around\n" +
            "W/A/S/D- Look around";

        s_camera = false;
        
        s_sensitivty = mouseSensitivity.value * 50f + 40f;
        fixedCamMovement.FC_speed = s_sensitivty;


        desktopFPS.image.fillCenter = true;
        desktopMouse.image.fillCenter = false;

        Menu.transform.SetParent(Fixed_transform);
        SettingsMenu.transform.SetParent(Fixed_transform);
        AircraftSelect.transform.SetParent(Fixed_transform);
        Help.transform.SetParent(Fixed_transform);

        Cursor.lockState = CursorLockMode.None;

        if (weaponSwap.active == true)
        {
            weaponSwap.animator.SetTrigger("Lower Tablet");
            weaponSwap.active = false;
        }
    }

    //Change to Desktop Mouse controls
    public void DesktopFPS()
    {
        FixedCamera.gameObject.SetActive(false);
        FPSCamera.gameObject.SetActive(true);

        s_camera = true;
        
        s_sensitivty = mouseSensitivity.value * 500f + 40f;
        desktopCamLooking.Sense = mouseSensitivity.value;

        helpText.text = "FPS Controls\n" +
            "W- Forwards\n" +
            "A- Left\n" +
            "S- Backwards\n" +
            "D- Right\n" +
            "Mouse- Looking around\n" +
            "Escape- Pause/Unpause\n" +
            "E- Raise/Lower Tablet";

        desktopFPS.image.fillCenter = false;
        desktopMouse.image.fillCenter = true;

        Menu.transform.SetParent(FPS_transform);
        SettingsMenu.transform.SetParent(FPS_transform);
        AircraftSelect.transform.SetParent(FPS_transform);
        Help.transform.SetParent(FPS_transform);

        Cursor.lockState = CursorLockMode.None;

        if(weaponSwap.active == true)
        {
            weaponSwap.animator.SetTrigger("Lower Tablet");
            weaponSwap.active = false;
        }
    }
}

