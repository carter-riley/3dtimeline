using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using UnityEngine.UI;


public class initializeVariables : MonoBehaviour
{

    public string narratives;

    public float smallestYear = 1;
    public float firstyear;
    public float secondyear;
    public float thirdyear;

    public int zPosition = 0;
    public int howClose = -800;

    public int numArtifacts = 0;

    // Use this for initialization
    void Start()
    {

        print("play time is: " + Time.realtimeSinceStartup.ToString());
        


        if (Time.realtimeSinceStartup < 15) {
            print("Pulling data from database");

            PlayerPrefs.SetInt("created", 0);

            string[] narrativeArrays = narratives.Split(',');


            FindObjectOfType<NarrativeManager>().narratives = narrativeArrays;

            string MyConString = "Server=147.222.163.1;UID=sdg7;Database=sdg7_DB;PWD=3dTimeline;Port=3306";
            MySqlConnection connect = new MySql.Data.MySqlClient.MySqlConnection(MyConString);

            try
            {
                connect.Open();

                // Read in data from all narratives
                int count = 0;
                foreach (string narrative in narrativeArrays)
                {
                    string sql = "SELECT COUNT(*) FROM " + narrative;

                    MySqlCommand command = new MySqlCommand(sql, connect);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        print(narrative + " has " + reader[0] + " items");
                        numArtifacts += Convert.ToInt16(reader[0]);
                    }

                    reader.Close();

                    //
                    // New Query Block
                    //

                    sql = "SELECT * FROM " + narrative;

                    command = new MySqlCommand(sql, connect);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string title;
                        string date;
                        string source;
                        string typeOf;
                        string format_type;
                        string description;
                        string webAddress;

                        title = reader.GetString(1);
                        description = reader.GetString(6);
                        try
                        {
                            date = reader.GetString(2);
                        }
                        catch
                        {
                            date = "Null";
                        }
                        try
                        {
                            typeOf = reader.GetString(5);
                        }
                        catch
                        {
                            typeOf = "Null";
                        }
                        try
                        {
                            webAddress = reader.GetString(7);
                        }
                        catch
                        {
                            webAddress = null;
                        }

                        FindObjectOfType<NarrativeManager>().artifactList.Add(new Artifact(title, date, description, typeOf, webAddress, narrative));
                    }

                    reader.Close();

                    //
                    // New Query Block
                    //

                    sql = "SELECT min(Date_id) FROM " + narrative;

                    command = new MySqlCommand(sql, connect);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        FindObjectOfType<NarrativeManager>().minDates.Add(reader.GetUInt16(0));
                    }

                    reader.Close();

                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                print("File: AddNewBillboards.cs. Exception: + " + ex);
            }

            connect.Close();

            // print("There are " + numArtifacts + " in all of the tables");

            // print("There are " + FindObjectOfType<NarrativeManager>().artifactList.Count + " items in artifact list.");

            //for(int i = 0; i < FindObjectOfType<NarrativeManager>().artifactList.Count; i++)
            //{
            //    print(FindObjectOfType<NarrativeManager>().artifactList[i].title);
            //}
        } else
        {
            print("Data has already been pulled, skipping");
        }

        print("play time is: " + Time.realtimeSinceStartup.ToString());

    }

    // Update is called once per frame
    void Update()
    {

    }
}
