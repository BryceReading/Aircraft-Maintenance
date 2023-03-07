using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class FixedCamMovement : MonoBehaviour
{
    [SerializeField]
    private float FC_smooth = 0.2f;

    private Vector3 FC_rotCur;
    private Vector3 FC_velSmooth = Vector3.zero;
    
    [SerializeField]
    private float FC_dist = 5.0f;

    [SerializeField]
    private Transform FC_target;

    [SerializeField]
    private float FC_speed;
    
    Settings FC_setting;

    private float FC_rotX;
    private float FC_rotY;

    public UI FC_ui;

    private void Start()
    {
        // FC_speed = FC_setting.s_sensitivty;
        FC_speed = 5f;
    }


    void Update()
    {
        // Mouse contols //
        float FC_mX = Input.GetAxis("Mouse X") * FC_speed;
        float FC_mY = Input.GetAxis("Mouse Y") * FC_speed;
        
        FC_rotY += FC_mX;
        FC_rotX += FC_mY;

        FC_rotX = Mathf.Clamp(FC_rotX, -90, 90);

        Vector3 FC_nextRot = new Vector3(FC_rotX, FC_rotY);
        FC_rotCur = Vector3.SmoothDamp(FC_rotCur, FC_nextRot, ref FC_velSmooth, FC_smooth);

        transform.localEulerAngles = FC_rotCur;

        transform.position = FC_target.position - transform.forward * FC_dist;

        //if (FC_ui.globalEnabled == true) { Cursor.lockState = CursorLockMode.None; }
        //else { Cursor.lockState = CursorLockMode.Locked; }

        // Adding keyboard contols A & D = Y axis W & S = X axis
        

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.up, FC_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.up, -FC_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) transform.Rotate(Vector3.right, FC_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) transform.Rotate(Vector3.right, -FC_speed * Time.deltaTime);
    }
}