using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;

public class AddNewBillboards : MonoBehaviour {

	public GameObject prefab;
    public int zPosition = 19;
    public string nameOfTimeline;
    public int howClose;
    //public float radius = 5f;

    public List<GameObject> billboardsList = new List<GameObject>();



    // Use this for initialization
    void Start () {
        bool left = true;
        float xPosition;
        int numberOfObjects = 5;


        try
        {
            MySqlConnection connect;
            string MyConString = "Server=147.222.163.1;UID=sdg7;Database=sdg7_DB;PWD=3dTimeline;Port=3306";
            connect = new MySql.Data.MySqlClient.MySqlConnection();
            connect.ConnectionString = MyConString;
            connect.Open();
            if (connect.State == ConnectionState.Open)
            {}
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
                FindObjectOfType<NarrativeManager>().titleList.Add(newReader.GetString(1));
                // print(newReader.GetString(1));
                // print(titleList[0]);
                FindObjectOfType<NarrativeManager>().descriptionList.Add(newReader.GetString(6));
                try
                {
                    FindObjectOfType<NarrativeManager>().dateList.Add(newReader.GetString(2));
                } catch
                {
                    FindObjectOfType<NarrativeManager>().dateList.Add("Null");
                }
                try
                {
                    FindObjectOfType<NarrativeManager>().typeList.Add(newReader.GetString(5));
                } catch
                {
                    FindObjectOfType<NarrativeManager>().typeList.Add("Null");
                }
                try
                {
                    FindObjectOfType<NarrativeManager>().urlList.Add(newReader.GetString(7));
                } catch
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

        for (int i = 0; i < numberOfObjects; i++)
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


            Vector3 pos = new Vector3((i - (i * 200))-howClose, 0, xPosition);
            GameObject newBillboard = Instantiate(prefab, pos, Quaternion.identity);
            //newBillboard.transform.localScale = new Vector3(0.1F, 0.1F, 0.1F);
            newBillboard.transform.position = new Vector3(newBillboard.transform.position.x, newBillboard.transform.position.y+7, newBillboard.transform.position.z);
            newBillboard.GetComponent<BillboardMonobehaviorFunctions>().boardNumber = billboardsList.Count;
            newBillboard.GetComponent<BillboardMonobehaviorFunctions>().table = nameOfTimeline;


            billboardsList.Add(newBillboard);
        }

	}

	// Update is called once per frame
	void Update () {

	}
}
