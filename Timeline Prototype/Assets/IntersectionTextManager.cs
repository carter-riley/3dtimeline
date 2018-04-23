using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System;

public class IntersectionTextManager : MonoBehaviour
{

    public GameObject textBox;

    public Text theText;
    public int fontSize;

    //public PlayerController PlayerCamera;

    // Use this for initialization
    void Start()
    {
        theText.fontSize = 40;
        theText.alignment = TextAnchor.MiddleCenter;

        // print("Text box manager, current title is: " + FindObjectOfType<NarrativeManager>().titleList[0] + ", url is " + FindObjectOfType<NarrativeManager>().urlList[0]);

        string intersectingNarrative = GetComponentInParent<BillboardMonobehaviorFunctions>().thisArtifact.IntersectWith;

        // int count = FindObjectOfType<NarrativeManager>().textCount;
        //print("Intersection text is: " + intersectingNarrative);
        theText.text = intersectingNarrative;

        // print(currentDate + " " + currentTitle);

        // GameObject parentObject = base.gameObject;
        // BillboardMonobehaviorFunctions monobehaviorFunctionsScript = this.GetComponentInParent<BillboardMonobehaviorFunctions>();
        // int newBoardNumber = monobehaviorFunctionsScript.boardNumber + 1;


        // FindObjectOfType<NarrativeManager>().textCount++;

        // titleList.RemoveAt(0);
    }

    void Update()
    {

    }
}
