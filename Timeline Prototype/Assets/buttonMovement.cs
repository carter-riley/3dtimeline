using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonMovement : MonoBehaviour
{
    public Button left;
    public Button right;
    public Button resetButton;
    public Text pathwayName1;
    public Text pathwayName2;
    public Text pathwayName3;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = -90.0f;
    private float pitch = 0.0f;

    private bool isRotating;	// Is the camera being rotated?
    private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
    public float turnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 4.0f;       // Speed of the camera when being panned
    public float zoomSpeed = 4.0f;

    public GameObject pathGameObject1;
    /*
        yaw += speedH* Input.GetAxis("Mouse X");
            if (!(pitch <= -35 && speedV* Input.GetAxis("Mouse Y") > 0 || pitch >= 20 && speedV* Input.GetAxis("Mouse Y") < 0))
            {
                pitch -= speedV* Input.GetAxis("Mouse Y");
    }

        //Debug.Log(pitch);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f); */
    void Start()
    {
        left.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        pathwayName1.gameObject.SetActive(false);
        pathwayName2.gameObject.SetActive(false);
        pathwayName3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float zcor = Camera.main.transform.position.z;
        // For Philanthropy Path
        if (zcor < 351 && zcor > 60)
        {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            pathwayName1.gameObject.SetActive(false);
        }
        if (zcor > -243 && zcor < 43)
        {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            pathwayName1.gameObject.SetActive(false);
        }
        if (zcor < 52 && zcor > 50)
        {
            left.gameObject.SetActive(false);
            right.gameObject.SetActive(false);
            pathwayName1.gameObject.SetActive(true);
        }
        // For Coming of Age Pathway
        if (zcor > 346 && zcor < 357)
        {
            left.gameObject.SetActive(false);
            right.gameObject.SetActive(false);
            pathwayName2.gameObject.SetActive(true);
        }
        if (zcor > 357 && zcor < 390)
        {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            pathwayName2.gameObject.SetActive(false);
        }
        if (zcor < 346 && zcor > 60)
        {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            pathwayName2.gameObject.SetActive(false);
        }
        // For Gonzaga Pathway 
        if (zcor < -243 && zcor > -255)
        {
            left.gameObject.SetActive(false);
            right.gameObject.SetActive(false);
            pathwayName3.gameObject.SetActive(true);
        }
        if (zcor < -255 && zcor > -700)
        {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            pathwayName3.gameObject.SetActive(false);
        }
    }

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

        RaycastHit hit;
        Ray downRay = new Ray(Camera.main.transform.position, Vector3.down);
        if (Physics.Raycast(downRay, out hit, 20))
        {
            if (hit.transform.gameObject == pathGameObject1)
            {

            }
            else
            {
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, 53); // 11 is a magic number which is the height the camera should be at// 20 is a magic number which is the center of the path
            }
        }
    }
    public void moveBackwards()
    {
        Camera.main.transform.position += Camera.main.transform.forward * Time.deltaTime * -500; //change the 500 to a public variable named movement speed
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, Camera.main.transform.position.z);

        RaycastHit hit;
        Ray downRay = new Ray(Camera.main.transform.position, Vector3.down);
        if (Physics.Raycast(downRay, out hit, 20))
        {
            if (hit.transform.gameObject == pathGameObject1)
            {

            }
            else
            {
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, 53); // 11 is a magic number which is the height the camera should be at// 20 is a magic number which is the center of the path
            }
        }
    }
    public void moveLeft()
    {
        Camera.main.transform.Translate(new Vector2(-20, 0));
    }
    public void moveRight()
    {
        Camera.main.transform.Translate(new Vector2(20, 0));
    }


    public void startAtBeginning()
    {
        //Camera.main.transform.position += Camera.main.transform.forward * Time.deltaTime * -500; //change the 500 to a public variable named movement speed
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, Camera.main.transform.position.z);

        RaycastHit hit;
        Ray downRay = new Ray(Camera.main.transform.position, Vector3.down);
        if (Physics.Raycast(downRay, out hit, 20))
        {
            if (hit.transform.gameObject == pathGameObject1)
            {

            }
            else
            {
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, 50); // 11 is a magic number which is the height the camera should be at// 20 is a magic number which is the center of the path
            }
        }
    }
}