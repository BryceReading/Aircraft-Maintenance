using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CameraChange : MonoBehaviour
{
    [HeaderAttribute("Camera keyboard Movment")]
    public float FC_speed;
    private GameObject FC_target;

    bool paused; 
    
    public UI FC_ui;

    void Start()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            FC_target = hit.transform.gameObject;
        }

        FC_speed = 70f;
    }

    void Update()
    {
        if(FC_ui == null)
        {
            
        }
        RotateCam();

        // change speed with scroll wheel
        FC_speed += Input.GetAxis("Mouse ScrollWheel") * 10;
        FC_speed = Mathf.Clamp(FC_speed, 5, 200);

    }

    void RotateCam()
    {
        // Rotate the camera with keyboard inputs at a set distance
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.up, FC_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.up, -FC_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) transform.Rotate(Vector3.right, FC_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) transform.Rotate(Vector3.right, -FC_speed * Time.deltaTime);
        if (Input.GetKeyDown("0") || Input.GetMouseButton(1)) transform.rotation = Quaternion.Euler(0, 0, 0);

        // Rotate the camera with mouse inputs
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * FC_speed * 10 * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * FC_speed * 10 * Time.deltaTime, Space.World);

        }

        // Lock mouse movment while the user is looking around but let it be usable when they need to click on the screen   
        if (FC_ui.globalEnabled == true) { Cursor.lockState = CursorLockMode.None; }
        else { Cursor.lockState = CursorLockMode.Locked; }

        // lock Z rotation of camera
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

        // zoom in and out with q and e and clamp the zoom
        if (Input.GetKey(KeyCode.Q)) transform.Translate(Vector3.forward * FC_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E)) transform.Translate(Vector3.back * FC_speed * Time.deltaTime);


    }

    //void FocusOnObject()
    //{
    //    // raycast out to find the object the user is looking at
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, transform.forward, out hit))
    //    {
    //        // if the object is a mesh, focus on it
    //        if (hit.collider.gameObject.GetComponent<MeshFilter>() != null)
    //        {
    //            target = hit.collider.gameObject;
    //            MeshFilter meshFillter = target.GetComponent<MeshFilter>();
    //            Mesh mesh = meshFillter.mesh;
    //            Bounds bound = mesh.bounds;

    //            Vector3 size = bound.size;
    //            Vector3 center = bound.center;

    //            // move the camera to the center of the object
    //            // transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - size.z);

    //            // rotate the camera to face the object
    //            transform.LookAt(center);
    //        }
    //    }
    //}
}


/*
 *         RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            target = hit.transform.gameObject;
        }

    //target = GameObject.Find("TargetObj");

        //MeshFilter meshFillter = target.GetComponent<MeshFilter>();
        //Mesh mesh = meshFillter.mesh;
        //Bounds bound = mesh.bounds;

        //Vector3 size = bound.size;
        //Vector3 center = bound.center;

*       [Old code needed]
*    [HeaderAttribute("Camera keyboard Movment")]
    public float speed = 10.0f;
    private GameObject target;

    void Start()
    {
        FocusOnObject();
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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.up, FC_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.up, -FC_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) transform.Rotate(Vector3.right, FC_speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) transform.Rotate(Vector3.right, -FC_speed * Time.deltaTime);

        if (Input.GetKeyDown("[0]")) transform.rotation = Quaternion.Euler(0, 0, 0);

        // Rotate the camera with mouse inputs
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * speed * 10 * Time.deltaTime);
            transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * speed * 10 * Time.deltaTime);

            // Lock mouse movment while the user is looking around but let it be usable when they need to click on the screen
            Cursor.lockState = CursorLockMode.Locked;
        }
        else { Cursor.lockState = CursorLockMode.None; }

        // lock Z rotation of camera
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

        // zoom in and out with q and e
        if (Input.GetKey(KeyCode.Q)) transform.Translate(Vector3.forward * speed * Time.deltaTime); 
        if (Input.GetKey(KeyCode.E)) transform.Translate(Vector3.back * speed * Time.deltaTime);

        // clamp zoom to object size
        if (transform.position.z > 0) transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);

    }

    void FocusOnObject()
    {
        // raycast out to find the object the user is looking at
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // if the object is a mesh, focus on it
            if (hit.collider.gameObject.GetComponent<MeshFilter>() != null)
            {
                target = hit.collider.gameObject;
                MeshFilter meshFillter = target.GetComponent<MeshFilter>();
                Mesh mesh = meshFillter.mesh;
                Bounds bound = mesh.bounds;

                Vector3 size = bound.size;
                Vector3 center = bound.center;

                // move the camera to the center of the object
               // transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - size.z);

                // rotate the camera to face the object
                transform.LookAt(center);
            }
        }
    }
*
* {Not working as needed}
*    [SerializeField] private Camera FC_camera;
    private GameObject FC_target;
    private float FC_distance = 10.0f;

    private Vector3 FC_prevPos;

    private void Start()
    {
        RaycastHit FC_hit;

        if (Physics.Raycast(transform.position, transform.forward, out FC_hit))
        {
            FC_target = FC_hit.transform.gameObject;
        }
    }

    void Update()
    {
      if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
      {
            Vector3 FC_newPos = FC_camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 FC_dir = FC_prevPos - FC_newPos;

            float FC_rotAroundY = -FC_dir.x * 180.0f;
            float FC_rotAroundX = -FC_dir.y * 180.0f;

            FC_camera.transform.position = FC_target.transform.position;

            FC_camera.transform.Rotate(new Vector3(1, 0, 0), FC_rotAroundX);
            FC_camera.transform.Rotate(new Vector3(0, 1, 0), FC_rotAroundY, Space.World);

            FC_camera.transform.Translate(new Vector3(0, 0, -FC_distance));

            FC_prevPos = FC_newPos;
      }
    }

*/