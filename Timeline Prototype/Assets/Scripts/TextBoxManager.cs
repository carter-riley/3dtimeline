using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System;

public class TextBoxManager : MonoBehaviour
{

    public GameObject textBox;

    public Text theText;
    public int fontSize;

    //public PlayerController PlayerCamera;

    // Use this for initialization
    void Start()
    {
        theText.fontSize = 40;
        theText.alignment = TextAnchor.UpperCenter;

        // print("Text box manager, current title is: " + FindObjectOfType<NarrativeManager>().titleList[0] + ", url is " + FindObjectOfType<NarrativeManager>().urlList[0]);


        // int count = FindObjectOfType<NarrativeManager>().textCount;

        if (FindObjectOfType<NarrativeManager>().dateList[0] == "Null" || FindObjectOfType<NarrativeManager>().titleList[0].Contains(theText.text = FindObjectOfType<NarrativeManager>().dateList[0])) {
            theText.text = FindObjectOfType<NarrativeManager>().titleList[0];
        } else {
            theText.text = FindObjectOfType<NarrativeManager>().dateList[0] + "\n" + FindObjectOfType<NarrativeManager>().titleList[0];
        }

        // GameObject parentObject = base.gameObject;
        // BillboardMonobehaviorFunctions monobehaviorFunctionsScript = this.GetComponentInParent<BillboardMonobehaviorFunctions>();
        // int newBoardNumber = monobehaviorFunctionsScript.boardNumber + 1;

        FindObjectOfType<NarrativeManager>().titleList.RemoveAt(0);
        FindObjectOfType<NarrativeManager>().dateList.RemoveAt(0);


        // FindObjectOfType<NarrativeManager>().textCount++;

        // titleList.RemoveAt(0);
    }

    void Update()
    {

    }
}
