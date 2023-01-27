using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitch : MonoBehaviour
{
    public GameObject FPS_cam;
    public GameObject Fixed_cam;
    public int mode = 0;

    private void Start()
    {
        FPS_cam.SetActive(true);
        Fixed_cam.SetActive(false);
    }

    public void SwitchCamera()
    {
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
         }
        if (mode == 1)
        {
            Fixed_cam.SetActive(true);
            FPS_cam.SetActive(false);
        }
    }
}
