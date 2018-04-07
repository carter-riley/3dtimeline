using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopRotating : MonoBehaviour {

    public GameObject target;
    public int CameraYPos;
    public int CameraZPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float targetZ = target.transform.position.z;
        float targetX = target.transform.position.x;
        Vector3 newLocation = new Vector3(targetX, CameraYPos, CameraZPos);
        transform.position = newLocation;
	}
}
