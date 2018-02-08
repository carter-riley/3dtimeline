using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonMovement : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = -90.0f;
    private float pitch = 0.0f;

    private bool isRotating;	// Is the camera being rotated?
    private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
    public float turnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 4.0f;       // Speed of the camera when being panned
    public float zoomSpeed = 4.0f;
/*
    yaw += speedH* Input.GetAxis("Mouse X");
        if (!(pitch <= -35 && speedV* Input.GetAxis("Mouse Y") > 0 || pitch >= 20 && speedV* Input.GetAxis("Mouse Y") < 0))
        {
            pitch -= speedV* Input.GetAxis("Mouse Y");
}

    //Debug.Log(pitch);

    transform.eulerAngles = new Vector3(pitch, yaw, 0.0f); */

public void moveCameraForward()
    {
        /*
        Camera.main.transform.position = new Vector3(

        0, Mathf.Clamp(Camera.main.transform.position.y, 0, 10), 20);
        */

        //Camera.main.transform.Translate(new Vector3(0, 0, 100));
        Camera.main.transform.position += Camera.main.transform.forward * Time.deltaTime * 500; //change the 500 to a public variable named movement speed
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, Camera.main.transform.position.z);
        //This code moves the player straight forward -- keep 4 ltr--- Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - 100, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }
    public void moveBackwards()
    {
        Camera.main.transform.position += Camera.main.transform.forward * Time.deltaTime * -500; //change the 500 to a public variable named movement speed
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, Camera.main.transform.position.z);
    }
    public void moveLeft()
    {
        Camera.main.transform.Translate(new Vector2(-20, 0));
    }
    public void moveRight()
    {
        Camera.main.transform.Translate(new Vector2(20, 0));
    }
}