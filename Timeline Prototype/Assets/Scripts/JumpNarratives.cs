﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpNarratives : MonoBehaviour {

    public int gonzagaZLoc;
    public int philanthropyZLoc;
    public int comingOfAgeZLoc;

    public Text philanthropyPathTitle;
    public Text comingOfAgePathTitle;
    public Text gonzagaPathTitle;

    public GameObject gonzagaBlueCircle;
    public GameObject comingOfAgeCircle;
    public GameObject philanthropyCircle;


    public void JumpToGonzaga()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, gonzagaZLoc);
        gonzagaPathTitle.gameObject.SetActive(true);
        philanthropyPathTitle.gameObject.SetActive(false);
        comingOfAgePathTitle.gameObject.SetActive(false);

        gonzagaBlueCircle.gameObject.SetActive(true);
        comingOfAgeCircle.gameObject.SetActive(false);
        philanthropyCircle.gameObject.SetActive(false);
    }

    public void JumpToPhilanthropy()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, philanthropyZLoc);
        philanthropyPathTitle.gameObject.SetActive(true);
        gonzagaPathTitle.gameObject.SetActive(false);
        comingOfAgePathTitle.gameObject.SetActive(false);

        gonzagaBlueCircle.gameObject.SetActive(false);
        comingOfAgeCircle.gameObject.SetActive(false);
        philanthropyCircle.gameObject.SetActive(true);
    }

    public void JumpToComingOfAge() {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, comingOfAgeZLoc);
        comingOfAgePathTitle.gameObject.SetActive(true);
        gonzagaPathTitle.gameObject.SetActive(false);
        philanthropyPathTitle.gameObject.SetActive(false);

        gonzagaBlueCircle.gameObject.SetActive(false);
        comingOfAgeCircle.gameObject.SetActive(true);
        philanthropyCircle.gameObject.SetActive(false);
    }

    

    public void ResetToStart()
    {
        Camera.main.transform.position = new Vector3(-137, 11, Camera.main.transform.position.z);
    }
}
