using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System;


public class DescriptionMananger : MonoBehaviour
{

    public GameObject textBox;
    public Text theText;

    // Use this for initialization
    void Start()
    {
        string description = EventViewData.Description;
        // string description = "sailed the ocean blue";

        theText.text = description;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
