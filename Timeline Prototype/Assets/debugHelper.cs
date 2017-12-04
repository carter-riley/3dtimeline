using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int billboardNumber = PlayerPrefs.GetInt ("billboardNumber");

		Debug.Log (billboardNumber);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
