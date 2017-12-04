﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirectionMovement : MonoBehaviour {

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    // Update is called once per frame
    void Update () {
        yaw += speedH * Input.GetAxis("Mouse X");
        if (!(pitch <= -35 && speedV * Input.GetAxis("Mouse Y") > 0 || pitch >= 20 && speedV * Input.GetAxis("Mouse Y") < 0))
        {
            pitch -= speedV * Input.GetAxis("Mouse Y");
        }

        //Debug.Log(pitch);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
	}
}
