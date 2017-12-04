using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCameraPosition : MonoBehaviour {

    public Camera mainCamera;

	// Use this for initialization
	void Start () {

        

        int cameraPosition = PlayerPrefs.GetInt("cameraPosition");

        if (cameraPosition != null)
        {
            mainCamera.transform.position = new Vector3(cameraPosition, 11, 19);
        }
        else
        {
        mainCamera.transform.position = new Vector3(cameraPosition, 11, 19); //starting postion

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
