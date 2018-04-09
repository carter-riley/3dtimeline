using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeManager : MonoBehaviour {

    public List<String> titleList = new List<String>();
    public List<String> descriptionList = new List<String>();
    public List<String> dateList = new List<String>();
    public List<String> typeList = new List<String>();
    public List<String> urlList = new List<String>();
    public List<Boolean> intersectionList = new List<Boolean>();

    public int currentNumber = 0;
    public int created = 0;
    // public int pictureCount = 0;
    // public int textCount = 0;


    // Use this for initialization
    void Start () {
        int x = 0;

        foreach (string elementOne in titleList)
        {
            // bool intersection = false;
            int count = 0;
            x++;

            foreach (string elementTwo in titleList)
            {
                if (elementOne.Equals(elementTwo))
                {
                    // print("True");
                    count++;
                }
            }
            print("The main loop has gone through: " + x + "times and count is: " + count);
            if (count > 1)
            {
                intersectionList.Add(true);
                print("There is an intersection.");
            }
            else
            {
                intersectionList.Add(false);
                print("There is not an intersection.");

            }
        }

        print("Length of intersection list is: " + intersectionList.Count);
        print("x is: " + x);


        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
