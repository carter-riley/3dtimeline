using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollMovement : MonoBehaviour {

    public int maxDate;
    public int minDate;

    public Slider slider;

    public Camera mainCamera;

    public Text yearText;

    public bool isDown;
    
    public float smallestYear;
    public GameObject managerObject;
    public bool firstTime;
    public bool secondTime;
    // Use this for initialization
    void Start () {
        firstTime = true;
        secondTime = true;
        smallestYear = managerObject.GetComponent<buttonMovement>().smallestYear;
        //print("SMALLEST YEAR ==" + smallestYear);
        slider.GetComponent<Slider>().maxValue = maxDate;
        slider.GetComponent<Slider>().minValue = smallestYear;

        float cameraXPos = PlayerPrefs.GetFloat("xpos");
        //float sliderValue = (cameraXPos - (600 * (smallestYear))) / 600;
        float sliderValue = (cameraXPos / 600) + smallestYear;
        //print("sliderValue SHOULD EQUALL ==" + sliderValue);
        slider.value = sliderValue;
	}

    public void onValueHasChanged() {
        float sliderCurrentVal = slider.value;
        float newXPos = (sliderCurrentVal - smallestYear) * 600;
        float cameraXPos = PlayerPrefs.GetFloat("xpos");
        //print("newXPos ==" + newXPos);
        if (firstTime)
        {
            //print("IN FIRST TIME!!!!!!!");
            firstTime = false;
            mainCamera.transform.position = new Vector3(cameraXPos, mainCamera.transform.position.y, mainCamera.transform.position.z);
        } else if(secondTime) {
            //print("In SECOND TIME!!!");
            secondTime = false;
            mainCamera.transform.position = new Vector3(cameraXPos, mainCamera.transform.position.y, mainCamera.transform.position.z);
        } else {
            //print("IN THE ELSE!!!!!");      
            mainCamera.transform.position = new Vector3(newXPos, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
        updateTime();
    }

    public void updateTime()
    {
        float yearDisplay = slider.value;
        yearText.text = yearDisplay.ToString();
        //print(yearText.text);
    }

    public void OnMouseDown()
    {
        isDown = true;
    }

    public void OnMouseUp()
    {
        isDown = false;
    }
    //float cameraXPos = PlayerPrefs.GetFloat("xpos");
    //float cameraZPos = PlayerPrefs.GetFloat("zpos");

    //    print("cameraXpos in ButtonMovement == " + cameraXPos);
    //    print("cameraZPos in buttonMovement == " + cameraZPos);

    //Camera.main.transform.position = new Vector3(cameraXPos, 11, cameraZPos);

    //PlayerPrefs.SetFloat("xpos", Camera.main.transform.position.x);
    //PlayerPrefs.SetFloat("zpos", Camera.main.transform.position.z);

}
