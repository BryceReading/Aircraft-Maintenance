using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera fixedCam;
    float rotate;

    public void RotateRight()
    {
        rotate = + 90;
        if (rotate > 360)
        {
            rotate = 0;
        }
        fixedCam.transform.Rotate(0, rotate, 0);
    }
}
