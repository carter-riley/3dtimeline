using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;

public class DescriptionManager : MonoBehaviour
{

    public GameObject textBox;

    public Text theText;


    //public PlayerController PlayerCamera;

    // Use this for initialization
    void Start()
    {
        try
        {
            MySqlConnection connect;


            //Connection string for Connector/ODBC 3.51
            // Driver={MariaDB ODBC 3.0 Driver};
            string MyConString = "Server=147.222.163.1;UID=criley2;Database=criley2_DB;PWD=;Port=3306";

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

            //Open connection

            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connect);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                theText.text = dataReader.GetString(7);
            }

            //close Data Reader                
            dataReader.Close();
            connect.Close();

            // Console.ReadKey();

        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            print("File: DescriptionManager.cs. Exception: + " + ex);
        }

    }

    void Update()
    {

    }
}
