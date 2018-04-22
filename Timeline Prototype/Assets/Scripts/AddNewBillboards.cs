using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using UnityEngine.UI;

public class AddNewBillboards : MonoBehaviour
{
    public float smallestYear = 1;
    public float firstyear;
    public float secondyear;
    public float thirdyear;
    public GameObject prefab;
    public GameObject prefabIntersection;
    public GameObject prefabNoImage;
    public GameObject prefabIntersectionNoImage;

    public int zPosition = 19;
    public string nameOfTimeline;
    public int howClose;

    //public float radius = 5f;

    public List<GameObject> billboardsList = new List<GameObject>();



    // Use this for initialization
    void Start()
    {
        int created = PlayerPrefs.GetInt("created");

        bool left = true;
        float xPosition;
        int numberOfObjects = 5;

        print("Created is: " + FindObjectOfType<NarrativeManager>().created);

        if (FindObjectOfType<NarrativeManager>().created < 3)
        {
            FindObjectOfType<NarrativeManager>().created++;

            try
            {
                MySqlConnection connect;
                string MyConString = "Server=147.222.163.1;UID=sdg7;Database=sdg7_DB;PWD=3dTimeline;Port=3306";
                connect = new MySql.Data.MySqlClient.MySqlConnection();
                connect.ConnectionString = MyConString;
                connect.Open();
                if (connect.State == ConnectionState.Open)
                { }
                string query = "SELECT COUNT(*) FROM " + nameOfTimeline;
                MySqlCommand cmd = new MySqlCommand(query, connect);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    numberOfObjects = dataReader.GetUInt16(0);
                }
                dataReader.Close();

                query = "SELECT * FROM " + nameOfTimeline;
                cmd = new MySqlCommand(query, connect);
                //Create a data reader and Execute the command
                MySqlDataReader newReader = cmd.ExecuteReader();
                while (newReader.Read())
                {
                    // 0: Record_id
                    // 1: Title
                    // 2: Date
                    // 3: Source
                    // 4: Type_of
                    // 5: format_type
                    // 6: description
                    // 7: URL
                    // newReader[0] + ", " + newReader[1] + ", " + newReader[2] + ", " + newReader[3] + ", " + newReader[4] + ", " + newReader[5] + ", " + newReader[6] + ", " + newReader[7]);

                    // FindObjectOfType<NarrativeManager>().

                    //try
                    //{
                    //    // print(newReader.GetString(1) + " " + newReader.GetString(7));
                    //} catch
                    //{
                    //    print(newReader.GetString(1) + " Null");
                    //}
                    string title;
                    string date;
                    string source;
                    string typeOf;
                    string format_type;
                    string description;
                    string webAddress;


                    title = newReader.GetString(1);
                    description = newReader.GetString(6);
                    try
                    {
                        date = newReader.GetString(2);
                    }
                    catch
                    {
                        date = "Null";
                    }
                    try
                    {
                        typeOf = newReader.GetString(5);
                    }
                    catch
                    {
                        typeOf = "Null";
                    }
                    try
                    {
                        webAddress = newReader.GetString(7);
                    }
                    catch
                    {
                        webAddress = null;
                    }

                    FindObjectOfType<NarrativeManager>().artifactList.Add(new Artifact(title, date, description, typeOf, webAddress, nameOfTimeline));

                }

                newReader.Close();
                connect.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                print("File: AddNewBillboards.cs. Exception: + " + ex);
            }
            // print("objects: " + numberOfObjects);


            //Finds earliest year in database
            try
            {
                MySqlConnection connect;
                string MyConString = "Server=147.222.163.1;UID=sdg7;Database=sdg7_DB;PWD=3dTimeline;Port=3306";
                connect = new MySql.Data.MySqlClient.MySqlConnection();
                connect.ConnectionString = MyConString;
                connect.Open();
                if (connect.State == ConnectionState.Open)
                {
                }
                string query = "SELECT min(Date_id) FROM gonzagatable";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    firstyear = dataReader.GetUInt16(0);
                }
                print("Firstyear: " + firstyear);
                dataReader.Close();

                query = "SELECT min(Date_id) FROM ComingofAgeTable";
                cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader2 = cmd.ExecuteReader();
                //Read the data and store them in the list
                while (dataReader2.Read())
                {
                    secondyear = dataReader2.GetUInt16(0);
                }
                print("secondyear: " + secondyear);
                dataReader2.Close();

                query = "SELECT min(Date_id) FROM philanthropyTable";
                cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader3 = cmd.ExecuteReader();
                //Read the data and store them in the list
                while (dataReader3.Read())
                {
                    thirdyear = dataReader3.GetUInt16(0);
                }
                print("thirdyear: " + thirdyear);
                dataReader3.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                print("File: AddNewBillboards.cs. Exception: + " + ex);
            }

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
            print("smallestYear Year is: " + smallestYear);

            int x = 0;

            foreach (Artifact elementOne in FindObjectOfType<NarrativeManager>().artifactList)
            {
                // bool intersection = false;
                int count = 0;

                foreach (Artifact elementTwo in FindObjectOfType<NarrativeManager>().artifactList)
                {
                    if (elementOne.Title.Equals(elementTwo.Title))
                    {
                        // print("True");
                        count++;
                    }
                }
                // print("The main loop has gone through: " + x + "times and count is: " + count);
                if (count > 1)
                {
                    FindObjectOfType<NarrativeManager>().artifactList[x].IsIntersection = true;
                    FindObjectOfType<NarrativeManager>().artifactList[x].IntersectWith = FindObjectOfType<NarrativeManager>().artifactList[count].Table;
                    // intersectionList.Add(true);
                    // print("There is an intersection.");
                }
                else
                {
                    FindObjectOfType<NarrativeManager>().artifactList[x].IsIntersection = false;
                    FindObjectOfType<NarrativeManager>().artifactList[x].IntersectWith = null;

                    // intersectionList.Add(false);
                    // print("There is not an intersection.");

                }
                x++;
            }
            for (int i = FindObjectOfType<NarrativeManager>().currentNumber; i < numberOfObjects + FindObjectOfType<NarrativeManager>().currentNumber; i++)
            {

                bool isIntersection = false;

                try
                {
                    // isIntersection = intersectionList[FindObjectOfType<NarrativeManager>().intersectionNumber];
                    isIntersection = FindObjectOfType<NarrativeManager>().artifactList[created].IsIntersection;
                    print("isInteresction " + isIntersection);
                    // intersectionList.RemoveAt(0);
                    // FindObjectOfType<NarrativeManager>().intersectionNumber++;
                    print("isInteresction2 " + isIntersection);
                }
                catch (Exception e)
                {
                    print("This is the error: " + e);
                }

                if (left)
                {
                    xPosition = -25f + zPosition;
                    left = false;
                }
                else
                {
                    xPosition = 125f + zPosition;
                    left = true;
                }

                double date;
                if (double.TryParse(FindObjectOfType<NarrativeManager>().artifactList[created].Date, out date))
                {
                    Console.WriteLine(date);

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
                for (int j = 0; j < i; j++)
                {
                    if (FindObjectOfType<NarrativeManager>().artifactList[created].Date == FindObjectOfType<NarrativeManager>().artifactList[j].Date)
                    {
                        date = date + 0.1;
                        stag++;
                    }
                }
                float date1 = (float)date;
                // print(FindObjectOfType<NarrativeManager>().titleList[i]);
                // print(i + "," + date + "x: " + (date - 1950) * 100);
                Vector3 pos = new Vector3((date1 - smallestYear) * 600, 0, xPosition);


                GameObject prefabName;

                print("script is running");
                if (FindObjectOfType<NarrativeManager>().artifactList[created].IsIntersection && FindObjectOfType<NarrativeManager>().artifactList[created].URL != null)
                {
                    print(FindObjectOfType<NarrativeManager>().artifactList[created].Title + " Has intersection and URL is not null");
                    // newBillboard = Instantiate(prefabIntersection, pos, Quaternion.identity);
                    prefabName = prefabIntersection;
                }
                else if (!FindObjectOfType<NarrativeManager>().artifactList[created].IsIntersection && FindObjectOfType<NarrativeManager>().artifactList[created].URL != null)
                {
                    print(FindObjectOfType<NarrativeManager>().artifactList[created].Title + " Does not have intersection and URL is not null");
                    // newBillboard = Instantiate(prefab, pos, Quaternion.identity);
                    prefabName = prefab;
                }
                else if (FindObjectOfType<NarrativeManager>().artifactList[created].IsIntersection && FindObjectOfType<NarrativeManager>().artifactList[created].URL == null)
                {
                    print(FindObjectOfType<NarrativeManager>().artifactList[created].Title + " Has intersection and URL is null");
                    // newBillboard = Instantiate(prefabIntersectionNoImage, pos, Quaternion.identity);
                    prefabName = prefabIntersectionNoImage;
                }
                else if (!FindObjectOfType<NarrativeManager>().artifactList[created].IsIntersection && FindObjectOfType<NarrativeManager>().artifactList[created].URL == null)
                {
                    print(FindObjectOfType<NarrativeManager>().artifactList[created].Title + " Does not have intersection and URL is null");
                    prefabName = prefabNoImage;
                } else
                {
                    print(FindObjectOfType<NarrativeManager>().artifactList[created].Title + " This is literally impossible");
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

                newBillboard.transform.position = new Vector3(newBillboard.transform.position.x, newBillboard.transform.position.y + 7, newBillboard.transform.position.z + zOffset);
                newBillboard.transform.Rotate(0, 180, 0);
                newBillboard.GetComponent<BillboardMonobehaviorFunctions>().boardNumber = billboardsList.Count;
                newBillboard.GetComponent<BillboardMonobehaviorFunctions>().table = nameOfTimeline;

                billboardsList.Add(newBillboard);
                DontDestroyOnLoad(newBillboard);
                created++;
            }
            // FindObjectOfType<NarrativeManager>().currentNumber += numberOfObjects;

            // print("something;");



        }


        PlayerPrefs.SetInt("created",created);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
