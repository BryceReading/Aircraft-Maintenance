using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitch : MonoBehaviour
{
    public GameObject FPS_cam;
    public GameObject Fixed_cam;
    public int mode = 0;

    public UI FPSUI;
    public UI FixedUI;

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

        if(FPSUI.settings.enabled == true)
        {
            FPSUI.settings.enabled = false;
            FixedUI.settings.enabled = true;
        }
        else if(FixedUI.settings.enabled == true)
        {
            FPSUI.settings.enabled = true;
            FixedUI.settings.enabled = false;
        }

        StartCoroutine(SwitchCam());
    }
    
    IEnumerator SwitchCam ()
    {
        yield return new WaitForSeconds(0.01f);
        
         if (mode == 0)
         {
              FPS_cam.SetActive(true);
              Fixed_cam.SetActive(false);
         }
        else if (mode == 1)
        {
            Fixed_cam.SetActive(true);
            FPS_cam.SetActive(false);
        }
        Time.timeScale = 0;
    }
}
