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
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked == true)
        {
            // focused the camera on the objecy being clicked
            cam.transform.LookAt(target);


            // bring the object close to the player relevent to the distance from the player
            target.position = Vector3.MoveTowards(target.position, cam.transform.position, 10f);
            
            clicked = false;
        }

        // reset the cam to the original position
        if (Input.GetMouseButtonUp(1))
        {
            // reset the camera to the original position
            cam.transform.rotation = Quaternion.identity;

            // resets the position of the object to the original position
            target.position = startPos;
        }
    }

    private void OnMouseDown()
    {
        // set the onject being clicked to the target
        target = this.transform;
        clicked = true;
    }
}
