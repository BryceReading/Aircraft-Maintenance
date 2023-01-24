using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [HeaderAttribute("Camera keyboard Movment")]
    public float speed;

    void Start()
    {
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

        //Maintain a set distance from the object usign raycasting
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            transform.position = hit.point;
        }

        // Zomming in and out


    }
}