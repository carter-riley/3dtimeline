using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;
using System.Text;
// using MySql.Data;
using MySql.Data.MySqlClient;
using UnityEngine.UI;


public class DatabaseConnector : MonoBehaviour
{

    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;

    // Use this for initialization
    void Start()
    {
        try
        {
            MySqlConnection connect;


            //Connection string for Connector/ODBC 3.51
            // Driver={MariaDB ODBC 3.0 Driver};
            string MyConString = "Server=localhost;UID=root;Database=omeka1;PWD=team7;Port=3306";

            connect = new MySql.Data.MySqlClient.MySqlConnection();

            connect.ConnectionString = MyConString;

            connect.Open();

            if (connect.State == ConnectionState.Open)
            {
                Console.WriteLine("Connection Successful");
                Console.WriteLine();
            }

            Console.WriteLine("Connection Information:");
            Console.WriteLine("\tConnection String:" + connect.ConnectionString);
            Console.WriteLine("\tConnection Timeout:" + connect.ConnectionTimeout);
            Console.WriteLine("\tDatabase:" + connect.Database);
            Console.WriteLine("\tDataSource:" + connect.DataSource);
            Console.WriteLine("\tServerVersion:" + connect.ServerVersion);
            Console.WriteLine();

            string query = "SELECT * FROM artifacts";

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


                Console.WriteLine(dataReader["Title"]);
                Console.WriteLine(dataReader["Date_id"]);
                Console.WriteLine(dataReader["Source"]);
                Console.WriteLine(dataReader["Type_of"]);
                Console.WriteLine(dataReader["format_type"]);
                Console.WriteLine(dataReader["URL"]);
                Console.WriteLine();
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

    // Update is called once per frame
    void Update()
    {

    }
}