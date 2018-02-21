﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraDirectionMovement : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = -90.0f;
    private float pitch = 0.0f;

    private bool isRotating;	// Is the camera being rotated?
    private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
    public float turnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 4.0f;       // Speed of the camera when being panned
    public float zoomSpeed = 4.0f;		// Speed of the camera going back and forth


    // Update is called once per frame
    void Update()
    {
        /*
        yaw += speedH * Input.GetAxis("Mouse X");
        if (!(pitch <= -35 && speedV * Input.GetAxis("Mouse Y") > 0 || pitch >= 20 && speedV * Input.GetAxis("Mouse Y") < 0))
        {
            pitch -= speedV * Input.GetAxis("Mouse Y");
        }

        //Debug.Log(pitch);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);  */

  

        if (Input.GetMouseButtonDown(1))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        if (!Input.GetMouseButton(1)) isRotating = false;

        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
            bool inBottom = Camera.main.transform.eulerAngles.x <= 30 && Camera.main.transform.eulerAngles.x >= 0;
            bool inTop = Camera.main.transform.eulerAngles.x >= 315 && Camera.main.transform.eulerAngles.x <= 360;
            if ((Camera.main.transform.eulerAngles.x > 325 && inTop || pos.y < 0 && inTop) || (Camera.main.transform.eulerAngles.x < 23 && inBottom || pos.y > 0 && inBottom)) { //top bound
                {
                    transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
                    transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
                }
            }
            print("inBottom == " + inBottom);
            print("pos.y == " + pos.y);
            print("Camera.main.transform.eulerAngles.x" + Camera.main.transform.eulerAngles.x);
            //print("y == " + Camera.main.transform.eulerAngles.y);
            //print("z == " + Camera.main.transform.eulerAngles.z);
        }
    }
}

