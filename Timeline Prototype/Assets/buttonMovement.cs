using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonMovement : MonoBehaviour
{


    public void moveCameraForward()
    {
        Camera.main.transform.Translate(new Vector3(20, 0, 0));
    }
    public void moveBackwards()
    {
        //Camera.main.transform.Translate(-10, 0, );
    }/*
    public void moveLeft()
    {

    }
    public void moveRight()
    {

    }*/
}