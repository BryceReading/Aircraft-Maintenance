using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopCamLooking : MonoBehaviour
{
    public float Sense = 100f;
    public Transform body;

    float xRotation = 0f;

    UI ui;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sense * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
    }
}