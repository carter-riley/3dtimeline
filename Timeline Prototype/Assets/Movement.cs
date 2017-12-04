using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    private float actualSpeed;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
        { //this is to add sprinting
            actualSpeed = speed * 4;
        }
        else {
            actualSpeed = speed;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3(0, 0, actualSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(0, 0, actualSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(actualSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position -= new Vector3(actualSpeed * Time.deltaTime, 0, 0);
        }
    }
}
