using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System;


public class DateManager : MonoBehaviour
{

    public GameObject textBox;
    public Text theText;

    // Use this for initialization
    void Start()
    {

        string date = EventViewData.Date;
        // string date = "1842";

        theText.text = date;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
