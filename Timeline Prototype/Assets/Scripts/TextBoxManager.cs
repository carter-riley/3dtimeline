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

    public GameObject managerObject; //gotta drag in the _Manager Object!!!!!!!!!

    //public PlayerController PlayerCamera;

    // Use this for initialization
    void Start()
    {
        theText.fontSize = 40;
        theText.alignment = TextAnchor.UpperCenter;

        // GameObject parentObject = base.gameObject;
        // AddNewBillboards addNewBillBoards = this.GetComponentInParent<AddNewBillboards>();

        // print(AddNewBillboards.GetComponentInParent<List<String>>().get);

        //GameObject parentObject = base.gameObject;
        //AddNewBillboards addNewBillboardsScript = this

        //AddNewBillboards addNewBillboardsScript = managerObject.GetComponent<AddNewBillboards>(); //this creates a script which u can then access ur variables from
        //addNewBillboardsScript.watevaUWannaGet //this is rougly how u should be able to access the variables
        // string title = GetComponent<AddNewBillboards>().titleList[0];
        // List<String> titleList = FindObjectOfType<AddNewBillboards>().titleList;

        // print("TextBoxManager Line 40");
        // print(titleList);

        //print(GetComponent<AddNewBillboards>().titleList[0]);

        int count = FindObjectOfType<NarrativeManager>().count;

        if (FindObjectOfType<NarrativeManager>().dateList[count] == "Null" || FindObjectOfType<NarrativeManager>().titleList[count].Contains(theText.text = FindObjectOfType<NarrativeManager>().dateList[count])) {
            theText.text = FindObjectOfType<NarrativeManager>().titleList[count];
        } else {
            theText.text = FindObjectOfType<NarrativeManager>().dateList[count] + "\n" + FindObjectOfType<NarrativeManager>().titleList[count];
        }

        // GameObject parentObject = base.gameObject;
        // BillboardMonobehaviorFunctions monobehaviorFunctionsScript = this.GetComponentInParent<BillboardMonobehaviorFunctions>();
        // int newBoardNumber = monobehaviorFunctionsScript.boardNumber + 1;

        FindObjectOfType<NarrativeManager>().count++;

        // titleList.RemoveAt(0);
    }

    void Update()
    {

    }
}
