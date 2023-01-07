using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjectFocus : MonoBehaviour
{
    Camera cam;
    Transform target;
    bool clicked;
    List<GameObject> objects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked == true)
        {
            // focused the camera on the objecy being clicked
            cam.transform.LookAt(target);

            clicked = false;
        }

        // reset the cam to the original position
        if (Input.GetMouseButtonUp(1))
        {
            cam.transform.rotation = Quaternion.identity;
        }
    }

    private void OnMouseDown()
    {
        // set the onject being clicked to the target
        target = this.transform;
        clicked = true;
    }
}
