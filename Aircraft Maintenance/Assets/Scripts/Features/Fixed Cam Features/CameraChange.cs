using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    //[Header("Camera Mouse Movment")]
    //public float hSpeed = 2.0f;
    //public float VSpeed = 2.0f;
    //private float yaw = 0.0f;
    //private float pitch = 0.0f;

    //public Transform target;
    //public Transform camTransform = null;
    //private Vector3 camOffset = Vector3.zero;
    //public float speedTurn = 3;

    //GameObject parent;

    [HeaderAttribute("Camera keyboard Movment")]
    public float speed;

    void Start()
    {
        //parent = new GameObject();
        //camTransform = Camera.main.transform;
        
        //parent.transform.position = target.position;
        //camTransform.parent = parent.transform;
        //camOffset = camTransform.position - target.position;
    }

    void Update()
    {
        RotateCam();
    }

    void RotateCam()
    {
        ///
        /// Rotate the camera with keyboard inputs
        /// 
        if (Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(Vector3.up, -speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow)) transform.Rotate(Vector3.up, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow)) transform.Rotate(Vector3.right, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow)) transform.Rotate(Vector3.right, -speed * Time.deltaTime);
        if (Input.GetKeyDown("[0]")) transform.rotation = Quaternion.Euler(0, 0, 0);

        //Maintain a set distance from the object
        //transform.position = transform.parent.position - transform.forward * 10;

        // Zomming in and out
        

        /// 
        /// Rotate the camera using the mouse
        /// 
        /* yaw += hSpeed * Input.GetAxis("Mouse X");
         pitch -= VSpeed * Input.GetAxis("Mouse Y");

         parent.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);*/
    }
}