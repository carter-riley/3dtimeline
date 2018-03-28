using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System;


public class TitleManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;

    // Use this for initialization
    void Start () {

        string title = EventViewData.Title;

        theText.text = title;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
