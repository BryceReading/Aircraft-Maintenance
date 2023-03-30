using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class FixedCamMovement : MonoBehaviour
{
    private float FC_smooth = 0.2f;

    private Vector3 FC_rotCur;
    private Vector3 FC_velSmooth = Vector3.zero;

    private float FC_dist = 5.0f;

    private GameObject FC_target;

    public float FC_speed;

    public Settings FC_setting;

    private float FC_rotX;
    private float FC_rotY;

    private UI FC_ui;

    private void Start()
    {
        FC_target = GameObject.FindWithTag("Model");

        FC_speed = 5f;
//        FC_speed = FC_setting.s_sensitivty;

        // sets camera position at the start 
        transform.position = FC_target.transform.position - transform.forward * FC_dist;
    }


    void Update()
    {
        // Mouse contols //
        if (Input.GetMouseButton(0))
        {
            float FC_mX = Input.GetAxis("Mouse X") * FC_speed * Time.deltaTime;
            float FC_mY = Input.GetAxis("Mouse Y") * FC_speed * Time.deltaTime;

            FC_rotY += FC_mX;
            FC_rotX += FC_mY;

            FC_rotX = Mathf.Clamp(FC_rotX, -90, 90);

            Vector3 FC_nextRot = new Vector3(FC_rotX, FC_rotY);
            FC_rotCur = Vector3.SmoothDamp(FC_rotCur, FC_nextRot, ref FC_velSmooth, FC_smooth);

            transform.localEulerAngles = FC_rotCur;

            transform.position = FC_target.transform.position - transform.forward * FC_dist;
        }

        // Keyboard controls 
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) transform.RotateAround(FC_target.transform.position, Vector3.up, 50f * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) transform.RotateAround(FC_target.transform.position, Vector3.up, -50f * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) transform.RotateAround(FC_target.transform.position, Vector3.right, 50f * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) transform.RotateAround(FC_target.transform.position, Vector3.right, -50f * Time.deltaTime);

        // Zoom controls //
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            transform.position = FC_target.transform.position - transform.forward * FC_dist;

            if (FC_dist > 1.5f)
            {
                FC_dist -= 0.5f;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            transform.position = FC_target.transform.position - transform.forward * FC_dist;

            if (FC_dist < 20f)
            {
                FC_dist += 0.5f;
            }
        }
    }
}
