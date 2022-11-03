using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopMovement : MonoBehaviour
{
    /*Player move & look variables*/
    public CharacterController controller;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * 5f * Time.deltaTime);
    }
}
