using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCameraPosition : MonoBehaviour {

    public Camera mainCamera;

	// Use this for initialization
	void Start () {

        

        //int cameraPosition = PlayerPrefs.GetInt("cameraPosition");
        float cameraXPos = PlayerPrefs.GetFloat("xPos");
        float cameraZPos = PlayerPrefs.GetFloat("zPos");

        mainCamera.transform.position = new Vector3(cameraXPos, 11, cameraZPos); //starting postion

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
