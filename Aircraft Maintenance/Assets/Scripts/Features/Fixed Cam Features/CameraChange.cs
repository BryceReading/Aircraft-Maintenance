using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CameraChange : MonoBehaviour
{
    [HeaderAttribute("Camera keyboard Movment")]
    public float speed = 10.0f;
    public GameObject target;

    void Start()
    {
        //target = GameObject.Find("TargetObj");
        
        MeshFilter meshFillter = target.GetComponent<MeshFilter>();
        Mesh mesh = meshFillter.mesh;
        Bounds bound = mesh.bounds;

        Vector3 size = bound.size;
        Vector3 center = bound.center;
    }

    void Update()
    {
        RotateCam();

        // change speed with scroll wheel
        speed += Input.GetAxis("Mouse ScrollWheel") * 10;
    }

    void RotateCam()
    {
        // Rotate the camera with keyboard inputs at a set distance
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.up, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.up, -speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) transform.Rotate(Vector3.right, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) transform.Rotate(Vector3.right, -speed * Time.deltaTime);
        if (Input.GetKeyDown("[0]")) transform.rotation = Quaternion.Euler(0, 0, 0);

        // Rotate the camera with mouse inputs
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * speed * 10 * Time.deltaTime);
            transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * speed * 10 * Time.deltaTime);

            // Lock mouse movment while the user is looking around but let it be usable when they need to click on the screen
            Cursor.lockState = CursorLockMode.Locked;
        } else
            Cursor.lockState = CursorLockMode.None;

        // lock Z rotation of camera
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

        // zoom in and out with q and e
        if (Input.GetKey(KeyCode.Q)) transform.Translate(Vector3.forward * speed * Time.deltaTime); 
        if (Input.GetKey(KeyCode.E)) transform.Translate(Vector3.back * speed * Time.deltaTime);

    }
}