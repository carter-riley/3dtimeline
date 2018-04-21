using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonMovement : MonoBehaviour
{
    public float reset = 300;
    public Text yearText;
    public float yearDisplay;
    public Button left;
    public Button right;
    public Button resetButton;
    public Text philanthropyPathTitle;
    public Text comingOfAgePathTitle;
    public Text gonzagaPathTitle;
    //public float speedH = 2.0f;
    //public float speedV = 2.0f;

    private float yaw = -90.0f;
    private float pitch = 0.0f;

    private bool isRotating;	// Is the camera being rotated?
    private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
    public float turnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 4.0f;       // Speed of the camera when being panned
    public float zoomSpeed = 4.0f;

    public int xForwardLimit;
    public int xBackwardsLimit;

    public int movementSpeed;
    public int fastMovementSpeed;

    public Slider slider;

    public GameObject pathGameObject1;
    /*
        yaw += speedH* Input.GetAxis("Mouse X");
            if (!(pitch <= -35 && speedV* Input.GetAxis("Mouse Y") > 0 || pitch >= 20 && speedV* Input.GetAxis("Mouse Y") < 0))
            {
                pitch -= speedV* Input.GetAxis("Mouse Y");
    }

        //Debug.Log(pitch);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f); */
    //void Start()
    //{
    //    left.gameObject.SetActive(false);
    //    right.gameObject.SetActive(false);
    //    pathwayName1.gameObject.SetActive(false);
    //    pathwayName2.gameObject.SetActive(false);
    //    pathwayName3.gameObject.SetActive(false);
    //}

    //public GameObject referenceToManager;

    GameObject gonzagaPath;
    GameObject philanthropyPath;
    GameObject comingOfAgePath;

    int middleOfGonzagaPath;
    int middleOfPhilanthropyPath;
    int middleOfComingOfAgePath;

    void Start()
    {

        

        yearDisplay = 0;
        yearText.text = "Year:  " + yearDisplay.ToString();
        gonzagaPath = this.gameObject.GetComponent<addPathways>().planeGonzaga;
        philanthropyPath = this.gameObject.GetComponent<addPathways>().planePhilanthropy;
        comingOfAgePath = this.gameObject.GetComponent<addPathways>().planeComingOfAge;

        middleOfGonzagaPath = this.gameObject.GetComponent<JumpNarratives>().gonzagaZLoc;
        middleOfPhilanthropyPath = this.gameObject.GetComponent<JumpNarratives>().philanthropyZLoc;
        middleOfComingOfAgePath = this.gameObject.GetComponent<JumpNarratives>().comingOfAgeZLoc;
        //int test = this.gameObject.GetComponent<addPathways>().xScaleGonzaga;
        //print("HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        //print(test);
        //print(gonzagaPath);
    }


    //void Update() {
    //reset -= Time.deltaTime;
    //if(reset < 1)
    //{
    //    //Application.LoadLevel("startScreen");
    //}

    //}


    //GameObject gonzagaPath = referenceToManager.GetComponent<addPathways>().gonzagaPath;

    //GameObject gonzagaPath = super.GetComponent<addPathways>.gonzagaPath;
    //GameObject GonzagaPath = this.GetComponent<addPathways>().GonzagaPath;
    //GameObject PhilanthropyPath;
    //GameObject ComingOfAgePath;


    public void moveCameraForward()
    {
        /*
        Camera.main.transform.position = new Vector3(

        0, Mathf.Clamp(Camera.main.transform.position.y, 0, 10), 20);
        */

        //Camera.main.transform.Translate(new Vector3(0, 0, 100));
        Camera.main.transform.position += Camera.main.transform.forward * movementSpeed;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, Camera.main.transform.position.z);
        //This code moves the player straight forward -- keep 4 ltr--- Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - 100, Camera.main.transform.position.y, Camera.main.transform.position.z);

        RaycastHit hit;
        Ray downRay = new Ray(Camera.main.transform.position, Vector3.down);
        if (!(Camera.main.transform.position.x > xForwardLimit)) //checks forwards limit
        {
            if (Physics.Raycast(downRay, out hit, 200))
            {
                //print(hit.transform.gameObject);
                //print(gonzagaPath);
                if (hit.transform.gameObject == gonzagaPath)
                {
                    gonzagaPathTitle.gameObject.SetActive(true);
                    philanthropyPathTitle.gameObject.SetActive(false);
                    comingOfAgePathTitle.gameObject.SetActive(false);

                }
                else if (hit.transform.gameObject == philanthropyPath)
                {
                    philanthropyPathTitle.gameObject.SetActive(true);
                    gonzagaPathTitle.gameObject.SetActive(false);
                    comingOfAgePathTitle.gameObject.SetActive(false);

                }
                else if (hit.transform.gameObject == comingOfAgePath)
                {
                    comingOfAgePathTitle.gameObject.SetActive(true);
                    gonzagaPathTitle.gameObject.SetActive(false);
                    philanthropyPathTitle.gameObject.SetActive(false);
                }
                else
                {
                    if (gonzagaPathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfGonzagaPath); // 11 is a magic number which is the height the camera should be at
                    }
                    else if (philanthropyPathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfPhilanthropyPath);
                    }
                    else if (comingOfAgePathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfComingOfAgePath);
                    }
                }
            }
        }
        else
        { //reverting location because boundary crossed
          //Camera.main.transform.position -= Camera.main.transform.forward * Time.deltaTime * 3000;
            if (gonzagaPathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xForwardLimit, 11, middleOfGonzagaPath); // 11 is a magic number which is the height the camera should be at
            }
            else if (philanthropyPathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xForwardLimit, 11, middleOfPhilanthropyPath);
            }
            else if (comingOfAgePathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xForwardLimit, 11, middleOfComingOfAgePath);
            }
            //Camera.main.transform.position = new Vector3(xForwardLimit, 11, Camera.main.transform.position.z);
        }
        updateTime();
        updateSliderPosition();
    }
    public void moveBackwards()
    {
        Camera.main.transform.position += Camera.main.transform.forward * -movementSpeed;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, Camera.main.transform.position.z);

        RaycastHit hit;
        Ray downRay = new Ray(Camera.main.transform.position, Vector3.down);

        if (!(Camera.main.transform.position.x < xBackwardsLimit))
        {
            if (Physics.Raycast(downRay, out hit, 200))
            {
                //print(hit.transform.gameObject);
                //print(gonzagaPath);
                if (hit.transform.gameObject == gonzagaPath)
                {
                    gonzagaPathTitle.gameObject.SetActive(true);
                    philanthropyPathTitle.gameObject.SetActive(false);
                    comingOfAgePathTitle.gameObject.SetActive(false);

                }
                else if (hit.transform.gameObject == philanthropyPath)
                {
                    philanthropyPathTitle.gameObject.SetActive(true);
                    gonzagaPathTitle.gameObject.SetActive(false);
                    comingOfAgePathTitle.gameObject.SetActive(false);

                }
                else if (hit.transform.gameObject == comingOfAgePath)
                {
                    comingOfAgePathTitle.gameObject.SetActive(true);
                    gonzagaPathTitle.gameObject.SetActive(false);
                    philanthropyPathTitle.gameObject.SetActive(false);
                }
                else
                {
                    if (gonzagaPathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfGonzagaPath); // 11 is a magic number which is the height the camera should be at
                    }
                    else if (philanthropyPathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfPhilanthropyPath);
                    }
                    else if (comingOfAgePathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfComingOfAgePath);
                    }
                }
            }
        }
        else
        {
            if (gonzagaPathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xBackwardsLimit, 11, middleOfGonzagaPath); // 11 is a magic number which is the height the camera should be at
            }
            else if (philanthropyPathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xBackwardsLimit, 11, middleOfPhilanthropyPath);
            }
            else if (comingOfAgePathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xBackwardsLimit, 11, middleOfComingOfAgePath);
            }
            //Camera.main.transform.position = new Vector3(xBackwardsLimit, 11, Camera.main.transform.position.z);
        }
        updateTime();
        updateSliderPosition();
    }

    public void moveCameraForwardFast()
    {
        /*
        Camera.main.transform.position = new Vector3(

        0, Mathf.Clamp(Camera.main.transform.position.y, 0, 10), 20);
        */

        //Camera.main.transform.Translate(new Vector3(0, 0, 100));
        Camera.main.transform.position += Camera.main.transform.forward * fastMovementSpeed;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, Camera.main.transform.position.z);
        //This code moves the player straight forward -- keep 4 ltr--- Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - 100, Camera.main.transform.position.y, Camera.main.transform.position.z);

        RaycastHit hit;
        Ray downRay = new Ray(Camera.main.transform.position, Vector3.down);
        if (!(Camera.main.transform.position.x > xForwardLimit))
        {
            if (Physics.Raycast(downRay, out hit, 200))
            {
                // print(hit.transform.gameObject);
                // print(gonzagaPath);
                if (hit.transform.gameObject == gonzagaPath)
                {
                    gonzagaPathTitle.gameObject.SetActive(true);
                    philanthropyPathTitle.gameObject.SetActive(false);
                    comingOfAgePathTitle.gameObject.SetActive(false);

                }
                else if (hit.transform.gameObject == philanthropyPath)
                {
                    philanthropyPathTitle.gameObject.SetActive(true);
                    gonzagaPathTitle.gameObject.SetActive(false);
                    comingOfAgePathTitle.gameObject.SetActive(false);

                }
                else if (hit.transform.gameObject == comingOfAgePath)
                {
                    comingOfAgePathTitle.gameObject.SetActive(true);
                    gonzagaPathTitle.gameObject.SetActive(false);
                    philanthropyPathTitle.gameObject.SetActive(false);
                }
                else
                {
                    if (gonzagaPathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfGonzagaPath); // 11 is a magic number which is the height the camera should be at
                    }
                    else if (philanthropyPathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfPhilanthropyPath);
                    }
                    else if (comingOfAgePathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfComingOfAgePath);
                    }
                }

            }
        }
        else
        { //reverting location because boundary crossed
            //Camera.main.transform.position -= Camera.main.transform.forward * Time.deltaTime * 150000;
            if (gonzagaPathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xForwardLimit, 11, middleOfGonzagaPath); // 11 is a magic number which is the height the camera should be at
            }
            else if (philanthropyPathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xForwardLimit, 11, middleOfPhilanthropyPath);
            }
            else if (comingOfAgePathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xForwardLimit, 11, middleOfComingOfAgePath);
            }
            //Camera.main.transform.position = new Vector3(xForwardLimit, 11, Camera.main.transform.position.z);
        }
        updateTime();
        updateSliderPosition();
    }

    public void moveCameraBackwardFast()
    {
        /*
        Camera.main.transform.position = new Vector3(

        0, Mathf.Clamp(Camera.main.transform.position.y, 0, 10), 20);
        */

        //Camera.main.transform.Translate(new Vector3(0, 0, 100));
        Camera.main.transform.position += Camera.main.transform.forward * -fastMovementSpeed;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, Camera.main.transform.position.z);
        //This code moves the player straight forward -- keep 4 ltr--- Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - 100, Camera.main.transform.position.y, Camera.main.transform.position.z);

        RaycastHit hit;
        Ray downRay = new Ray(Camera.main.transform.position, Vector3.down);
        if (!(Camera.main.transform.position.x < xBackwardsLimit))
        {
            if (Physics.Raycast(downRay, out hit, 200))
            {
                // print(hit.transform.gameObject);
                // print(gonzagaPath);
                if (hit.transform.gameObject == gonzagaPath)
                {
                    gonzagaPathTitle.gameObject.SetActive(true);
                    philanthropyPathTitle.gameObject.SetActive(false);
                    comingOfAgePathTitle.gameObject.SetActive(false);

                }
                else if (hit.transform.gameObject == philanthropyPath)
                {
                    philanthropyPathTitle.gameObject.SetActive(true);
                    gonzagaPathTitle.gameObject.SetActive(false);
                    comingOfAgePathTitle.gameObject.SetActive(false);

                }
                else if (hit.transform.gameObject == comingOfAgePath)
                {
                    comingOfAgePathTitle.gameObject.SetActive(true);
                    gonzagaPathTitle.gameObject.SetActive(false);
                    philanthropyPathTitle.gameObject.SetActive(false);
                }
                else
                {
                    if (gonzagaPathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfGonzagaPath); // 11 is a magic number which is the height the camera should be at
                    }
                    else if (philanthropyPathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfPhilanthropyPath);
                    }
                    else if (comingOfAgePathTitle.IsActive())
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, middleOfComingOfAgePath);
                    }
                }
            }
        }
        else
        {
            //Camera.main.transform.position += Camera.main.transform.forward * Time.deltaTime * 150000;
            if (gonzagaPathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xBackwardsLimit, 11, middleOfGonzagaPath); // 11 is a magic number which is the height the camera should be at
            }
            else if (philanthropyPathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xBackwardsLimit, 11, middleOfPhilanthropyPath);
            }
            else if (comingOfAgePathTitle.IsActive())
            {
                Camera.main.transform.position = new Vector3(xBackwardsLimit, 11, middleOfComingOfAgePath);
            }
            //Camera.main.transform.position = new Vector3(xBackwardsLimit, 11, Camera.main.transform.position.z);
        }
        updateTime();
        updateSliderPosition();
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
    public void updateTime()
    {
        Vector3 pos = transform.position;
        pos.x = Camera.main.transform.position.x;
        yearDisplay = Mathf.Round((pos.x / 600) + 1900);
        yearText.text = yearDisplay.ToString();
        //print(yearText.text);
    }

    public void updateSliderPosition() {
        Vector3 pos = transform.position;
        pos.x = Camera.main.transform.position.x;
        slider.value = Mathf.Round((pos.x / 600) + 1900);
    }
}