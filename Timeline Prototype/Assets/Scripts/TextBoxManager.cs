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

        try
        {
            MySqlConnection connect;


            //Connection string for Connector/ODBC 3.51
            // Driver={MariaDB ODBC 3.0 Driver};
            string MyConString = "Server=147.222.163.1;UID=sdg7;Database=sdg7_DB;PWD=3dTimeline;Port=3306";

            connect = new MySql.Data.MySqlClient.MySqlConnection();

            connect.ConnectionString = MyConString;

            connect.Open();

            if (connect.State == ConnectionState.Open)
            {

            }
            GameObject parentObject = base.gameObject;
            BillboardMonobehaviorFunctions monobehaviorFunctionsScript = this.GetComponentInParent<BillboardMonobehaviorFunctions>();
            int newBoardNumber = monobehaviorFunctionsScript.boardNumber + 1;
            string currentNarrative = monobehaviorFunctionsScript.table;
            string query = "SELECT * FROM " + currentNarrative + " WHERE Number = " + newBoardNumber;

            //theText.text = newBoardNumber;
            // Debug.Log(newBoardNumber);

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection

            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connect);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                // theText.text = dataReader["Record_id"];

                string data = "";

                try
                {
                    data += dataReader.GetString(2) + "\n";
                } catch
                {
                    print("Date is null for billboard " + newBoardNumber + " on narrative " + currentNarrative);
                }

                data += dataReader.GetString(1);

                theText.text = data;

                // Console.WriteLine(dataReader["Date_id"]);
                // Console.WriteLine(dataReader["Source"]);
                // Console.WriteLine(dataReader["Type_of"]);
                // Console.WriteLine(dataReader["format_type"]);
                // Console.WriteLine(dataReader["URL"]);
            }

            //close Data Reader                
            dataReader.Close();
            connect.Close();

            // Console.ReadKey();

        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {

        }

    }

    void Update()
    {

    }
}
