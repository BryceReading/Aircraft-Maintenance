using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitch : MonoBehaviour
{
    public GameObject FPS_cam;
    public GameObject Fixed_cam;
    public Transform Fixed_transform;
    public Transform FPS_transform;
    public int mode = 0;

    public Canvas Menu;
    public Canvas Settings;
    public Canvas AircraftSelect;
    public Canvas Help;

    private void Start()
    {
        FPS_cam.SetActive(true);
        Fixed_cam.SetActive(false);
    }

    public void SwitchCamera()
    {
        Time.timeScale = 1;

        if (mode == 1) mode = 0;
        else mode += 1;

        StartCoroutine(SwitchCam());
    }
    
    IEnumerator SwitchCam ()
    {
        yield return new WaitForSeconds(0.01f);
        
        if (mode == 0)
        {
            FPS_cam.SetActive(true);
            Fixed_cam.SetActive(false);

            Menu.transform.SetParent(FPS_transform);
            Settings.transform.SetParent(FPS_transform);
            AircraftSelect.transform.SetParent(FPS_transform);
            Help.transform.SetParent(FPS_transform);
        }
        else if (mode == 1)
        {
            Fixed_cam.SetActive(true);
            FPS_cam.SetActive(false);

            Menu.transform.SetParent(Fixed_transform);
            Settings.transform.SetParent(Fixed_transform);
            AircraftSelect.transform.SetParent(Fixed_transform);
            Help.transform.SetParent(Fixed_transform);
        }

        Time.timeScale = 0;
    }
}
