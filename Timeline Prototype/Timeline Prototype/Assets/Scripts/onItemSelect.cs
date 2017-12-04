using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onItemSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Debug.Log("Loaded");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	void OnMouseDown()
	{
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel("DetailScreen");
#pragma warning restore CS0618 // Type or member is obsolete
        Debug.Log("It Works");
	}
}
