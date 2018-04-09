using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using UnityEngine.UI;

public class AddNewBillboards : MonoBehaviour
{

    
    public GameObject prefab;
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


                    FindObjectOfType<NarrativeManager>().titleList.Add(newReader.GetString(1));
                    // print(newReader.GetString(1));
                    // print(titleList[0]);
                    FindObjectOfType<NarrativeManager>().descriptionList.Add(newReader.GetString(6));
                    try
                    {
                        FindObjectOfType<NarrativeManager>().dateList.Add(newReader.GetString(2));
                    }
                    catch
                    {
                        FindObjectOfType<NarrativeManager>().dateList.Add("Null");
                    }
                    try
                    {
                        FindObjectOfType<NarrativeManager>().typeList.Add(newReader.GetString(5));
                    }
                    catch
                    {
                        FindObjectOfType<NarrativeManager>().typeList.Add("Null");
                    }
                    try
                    {
                        FindObjectOfType<NarrativeManager>().urlList.Add(newReader.GetString(7));
                    }
                    catch
                    {
                        FindObjectOfType<NarrativeManager>().urlList.Add("Null");
                    }
                }

                newReader.Close();
                connect.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                print("File: AddNewBillboards.cs. Exception: + " + ex);
            }
            // print("objects: " + numberOfObjects);
            for (int i = FindObjectOfType<NarrativeManager>().currentNumber; i < numberOfObjects + FindObjectOfType<NarrativeManager>().currentNumber; i++)
            {
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
                if (double.TryParse(FindObjectOfType<NarrativeManager>().dateList[i], out date))
                    Console.WriteLine(date);


                else
                    Console.WriteLine("String could not be parsed.");
                if (date == 0)
                {
                    date = 1950;
                }
                int stag = 0;
                for (int j = 0; j < i; j++)
                {
                    if (FindObjectOfType<NarrativeManager>().dateList[i] == FindObjectOfType<NarrativeManager>().dateList[j])
                    {
                        date = date + 0.6;
                        stag++;
                    }
                }
                float date1 = (float)date;
                // print(FindObjectOfType<NarrativeManager>().titleList[i]);
                // print(i + "," + date + "x: " + (date - 1950) * 100);
                Vector3 pos = new Vector3((date1 - 1950) * 100, 0, xPosition);

                GameObject newBillboard = Instantiate(prefab, pos, Quaternion.identity);
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
            }
            // FindObjectOfType<NarrativeManager>().currentNumber += numberOfObjects;

            // print("something;");

           

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
