using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOrientation : MonoBehaviour
{
    Vector3 previousePos = Vector3.zero;
    Vector3 deltPos = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        // Drag to move the object around
        if (Input.GetMouseButton(0) )
        {
            deltPos = Input.mousePosition - previousePos;
            this.transform.Rotate(Vector3.up, -deltPos.x, Space.World);
            this.transform.Rotate(Vector3.right, deltPos.y, Space.World);
        }
        else if (Input.GetMouseButtonUp(1)) {
            // Reset the object orientation
            this.transform.rotation = Quaternion.identity;
            // Reset object scale
        }
        
        if (Input.mouseScrollDelta.y != 0 )
        {
           this.transform.Translate(Vector3.forward * Input.mouseScrollDelta.y * .5f, Space.World);
        }

        previousePos = Input.mousePosition;
    }
}
