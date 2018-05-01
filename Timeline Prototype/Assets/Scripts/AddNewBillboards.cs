using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using UnityEngine.UI;

public class AddNewBillboards : MonoBehaviour
{
    float smallestYear = 1;
    float firstyear;
    float secondyear;
    float thirdyear;
    public GameObject prefab;
    public GameObject prefabIntersection;
    public GameObject prefabNoImage;
    public GameObject prefabIntersectionNoImage;

    public int zPosition = 19;
    // public string nameOfTimeline;
    public int howClose;

    //public float radius = 5f;

    public List<GameObject> billboardsList = new List<GameObject>();



    // Use this for initialization
    void Start()
    {
        // int created = PlayerPrefs.GetInt("created");

        bool left = true;
        float xPosition;
        int numberOfObjects = 5;

        // print("Created is: " + FindObjectOfType<NarrativeManager>().created);




        //Finds earliest year in database
        firstyear = FindObjectOfType<NarrativeManager>().minDates[0];
        secondyear = FindObjectOfType<NarrativeManager>().minDates[1];
        thirdyear = FindObjectOfType<NarrativeManager>().minDates[2];


        if (firstyear < secondyear && firstyear < thirdyear)
        {
            smallestYear = firstyear;
        }
        else if (secondyear < firstyear && secondyear < thirdyear)
        {
            smallestYear = secondyear;
        }
        else
        {
            smallestYear = thirdyear;
        }
        // print("smallestYear Year is: " + smallestYear);


        //for (int i = 0; i < FindObjectOfType<NarrativeManager>().artifactList.Count; i++)
        //{
        //    for (int j = 0; j < FindObjectOfType<NarrativeManager>().artifactList.Count; j++)
        //    {
        //        if (i == j)
        //        {
        //            // Same artifact
        //            // Do Nothing
        //            // print("i is j");
        //        }
        //        else if (FindObjectOfType<NarrativeManager>().artifactList[i].Title == FindObjectOfType<NarrativeManager>().artifactList[j].Title)
        //        {
        //            // print("i is " + i + ", j is " + j);
        //            // print(FindObjectOfType<NarrativeManager>().artifactList[i].Title + " intersects with " + FindObjectOfType<NarrativeManager>().artifactList[j].Title);
        //            FindObjectOfType<NarrativeManager>().artifactList[i].IsIntersection = true;
        //            FindObjectOfType<NarrativeManager>().artifactList[i].IntersectWith = FindObjectOfType<NarrativeManager>().artifactList[j].Table;
        //        }
        //        else
        //        {
        //            FindObjectOfType<NarrativeManager>().artifactList[i].IsIntersection = false;
        //        }
        //    }
        //}




        int newZ = 0;
        for (int j = 0; j < FindObjectOfType<NarrativeManager>().artifactList.Count; j++)
        {
            // bool intersection = false

            for (int i = 0; i < FindObjectOfType<NarrativeManager>().artifactList.Count; i++)
            {
                if (i == j)
                {
                    // Same artifact
                    // Do Nothing
                    // print("i is j");
                }
                else if (FindObjectOfType<NarrativeManager>().artifactList[j].Title.Equals(FindObjectOfType<NarrativeManager>().artifactList[i].Title))
                {
                    // print("i is " + i + ", j is " + j);
                    // print(FindObjectOfType<NarrativeManager>().artifactList[i].Title + " intersects with " + FindObjectOfType<NarrativeManager>().artifactList[j].Title);
                    FindObjectOfType<NarrativeManager>().artifactList[j].IsIntersection = true;
                    FindObjectOfType<NarrativeManager>().artifactList[j].IntersectWith = FindObjectOfType<NarrativeManager>().artifactList[j].Table;
                }
                else
                {
                    // FindObjectOfType<NarrativeManager>().artifactList[j].IsIntersection = false;
                }
            }

                if (FindObjectOfType<NarrativeManager>().artifactList[j].Table == FindObjectOfType<NarrativeManager>().narratives[0])
            {
                newZ = 0;
            }
            else if (FindObjectOfType<NarrativeManager>().artifactList[j].Table == FindObjectOfType<NarrativeManager>().narratives[1])
            {
                newZ = 300;
            }
            else if (FindObjectOfType<NarrativeManager>().artifactList[j].Table == FindObjectOfType<NarrativeManager>().narratives[2])
            {
                newZ = -300;
            }


            bool isIntersection = false;

            try
            {
                // isIntersection = intersectionList[FindObjectOfType<NarrativeManager>().intersectionNumber];
                isIntersection = FindObjectOfType<NarrativeManager>().artifactList[j].IsIntersection;
                // print("isInteresction " + isIntersection);
                // intersectionList.RemoveAt(0);
                // FindObjectOfType<NarrativeManager>().intersectionNumber++;
                // print("isInteresction2 " + isIntersection);
            }
            catch (Exception e)
            {
                print("This is the error: " + e);
            }

            if (left)
            {
                xPosition = -50f + newZ;
                left = false;
            }
            else
            {
                xPosition = 125f + newZ;
                left = true;
            }

            double date;
            if (double.TryParse(FindObjectOfType<NarrativeManager>().artifactList[j].Date, out date))
            {
                // print(date + " is " + FindObjectOfType<NarrativeManager>().artifactList[j].Date);

            }
            else
            {
                Console.WriteLine("String could not be parsed.");
            }
            if (date == 0)
            {
                date = 1950;
            }
            int stag = 0;
            for (int i = 0; i < j; i++)
            {
                if (FindObjectOfType<NarrativeManager>().artifactList[j].Table == FindObjectOfType<NarrativeManager>().artifactList[i].Table)
                {
                    if (FindObjectOfType<NarrativeManager>().artifactList[j].Date == FindObjectOfType<NarrativeManager>().artifactList[i].Date)
                    {

                        date = date + 0.1;
                        stag++;
                    }
                }
            }
            float date1 = (float)date;
            // print(FindObjectOfType<NarrativeManager>().titleList[i]);
            // print(i + "," + date + "x: " + (date - 1950) * 100);
            Vector3 pos = new Vector3((date1 - smallestYear) * 600, 7, xPosition);


            GameObject prefabName;

            // print("script is running");
            if (FindObjectOfType<NarrativeManager>().artifactList[j].IsIntersection == true && FindObjectOfType<NarrativeManager>().artifactList[j].URL != null)
            {
                // print(FindObjectOfType<NarrativeManager>().artifactList[j].Title + " Has intersection and URL is not null");
                // newBillboard = Instantiate(prefabIntersection, pos, Quaternion.identity);
                prefabName = prefabIntersection;
            }
            else if (FindObjectOfType<NarrativeManager>().artifactList[j].IsIntersection == false && FindObjectOfType<NarrativeManager>().artifactList[j].URL != null)
            {
                // print(FindObjectOfType<NarrativeManager>().artifactList[j].Title + " Does not have intersection and URL is not null");
                // newBillboard = Instantiate(prefab, pos, Quaternion.identity);
                prefabName = prefab;
            }
            else if (FindObjectOfType<NarrativeManager>().artifactList[j].IsIntersection == true && FindObjectOfType<NarrativeManager>().artifactList[j].URL == null)
            {
                // print(FindObjectOfType<NarrativeManager>().artifactList[j].Title + " Has intersection and URL is null");
                // newBillboard = Instantiate(prefabIntersectionNoImage, pos, Quaternion.identity);
                prefabName = prefabIntersectionNoImage;
            }
            else if (FindObjectOfType<NarrativeManager>().artifactList[j].IsIntersection == false && FindObjectOfType<NarrativeManager>().artifactList[j].URL == null)
            {
                // print(FindObjectOfType<NarrativeManager>().artifactList[j].Title + " Does not have intersection and URL is null");
                prefabName = prefabNoImage;
            }
            else
            {
                print(FindObjectOfType<NarrativeManager>().artifactList[j].Title + " This is literally impossible");
                prefabName = prefab;
            }

            GameObject newBillboard = Instantiate(prefabName, pos, Quaternion.identity);

            //newBillboard.transform.localScale = new Vector3(0.1F, 0.1F, 0.1F);
            int zOffset = 0;
            if (stag > 0)
            {
                if (stag % 2 == 0)
                {
                    zOffset = -20;
                }
                else
                {
                    zOffset = 20;
                }
            }
            // print(date + ", " + FindObjectOfType<NarrativeManager>().artifactList[j].Table + ", " + FindObjectOfType<NarrativeManager>().artifactList[j].Title);
            newBillboard.transform.position = pos; //new Vector3(newBillboard.transform.position.x, newBillboard.transform.position.y + 7, newBillboard.transform.position.z + zOffset);
            newBillboard.transform.Rotate(0, 180, 0);
            newBillboard.GetComponent<BillboardMonobehaviorFunctions>().boardNumber = billboardsList.Count;
            newBillboard.GetComponent<BillboardMonobehaviorFunctions>().table = FindObjectOfType<NarrativeManager>().artifactList[j].Table;

            billboardsList.Add(newBillboard);
            DontDestroyOnLoad(newBillboard);
        }

        // FindObjectOfType<NarrativeManager>().currentNumber += numberOfObjects;

        // print("something;");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
