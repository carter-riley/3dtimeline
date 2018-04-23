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
    // Use this for initialization
    void Start () {
        smallestYear = managerObject.GetComponent<buttonMovement>().smallestYear;
        //print("SMALLEST YEAR ==" + smallestYear);
        slider.GetComponent<Slider>().maxValue = maxDate;
        slider.GetComponent<Slider>().minValue = smallestYear;
	}

    public void onValueHasChanged() {
        float sliderCurrentVal = slider.value;
        float newXPos = (sliderCurrentVal - smallestYear) * 600;
        //print("newXPos ==" + newXPos);
        mainCamera.transform.position = new Vector3(newXPos, mainCamera.transform.position.y, mainCamera.transform.position.z);
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

}
