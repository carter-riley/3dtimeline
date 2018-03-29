using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraDirectionMovement : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = -90.0f;
    private float pitch = 0.0f;

    private bool isRotating; // Is the camera being rotated?
    //private Vector3 mouseOrigin; // Position of cursor when mouse dragging starts
    public float turnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 4.0f;       // Speed of the camera when being panned
    public float zoomSpeed = 4.0f; // Speed of the camera going back and forth

    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;

    void Start()
    {
        xAngle = -90;
        yAngle = 0;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
    }

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

        //if (Input.GetMouseButtonDown(1))
        //{
        //    // Get mouse origin
        //    mouseOrigin = Input.mousePosition;
        //    isRotating = true;
        //}

        //if (!Input.GetMouseButton(1)) isRotating = false;

        //if (isRotating)
        //{
        //    Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);


        //    bool inBottom = Camera.main.transform.eulerAngles.x <= 30 && Camera.main.transform.eulerAngles.x >= 0;
        //    bool inTop = Camera.main.transform.eulerAngles.x >= 315 && Camera.main.transform.eulerAngles.x <= 360;
        //    if ((Camera.main.transform.eulerAngles.x > 325 && inTop || pos.y < 0 && inTop) || (Camera.main.transform.eulerAngles.x < 23 && inBottom || pos.y > 0 && inBottom)) { //top bound

        //        transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
        //        transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);

        //    }
        //}
        //Source: https://answers.unity.com/questions/805630/how-can-%C4%B1-rotate-camera-with-touch.html
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                FirstPoint = Input.GetTouch(0).position;
                xAngleTemp = xAngle;
                yAngleTemp = yAngle;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                SecondPoint = Input.GetTouch(0).position;
                xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * -90 / Screen.height;
                yAngle = Mathf.Clamp(yAngle, -20, 35);
                xAngle = Mathf.Clamp(xAngle, -150, -30);
                this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
            }
        }
        //Vector3 pos = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position - TouchPhase.Began);
        //bool inBottom = Camera.main.transform.eulerAngles.x <= 30 && Camera.main.transform.eulerAngles.x >= 0;
        //bool inTop = Camera.main.transform.eulerAngles.x >= 315 && Camera.main.transform.eulerAngles.x <= 360;
        //if ((Camera.main.transform.eulerAngles.x > 325 && inTop || pos.y < 0 && inTop) || (Camera.main.transform.eulerAngles.x < 23 && inBottom || pos.y > 0 && inBottom)) { //top bound

        //    transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
        //    transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);

        //    }



    }
}

/* Code for touch controls
function Update()
{
    //Check count touches
    if (Input.touchCount > 0)
    {
        //Touch began, save position
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            firstpoint = Input.GetTouch(0).position;
            xAngTemp = xAngle;
            yAngTemp = yAngle;
        }
        //Move finger by screen
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            secondpoint = Input.GetTouch(0).position;
            //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
            xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0 / Screen.width;
            yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90.0 / Screen.height;
            //Rotate camera
            this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0);
        }
    }
}
*/
