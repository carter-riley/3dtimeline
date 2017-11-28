using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;

public class TextBoxManager2 : MonoBehaviour
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
            string MyConString = "Server=localhost;UID=root;Database=omeka1;PWD=team7;Port=3306";

            connect = new MySql.Data.MySqlClient.MySqlConnection();

            connect.ConnectionString = MyConString;

            connect.Open();

            if (connect.State == ConnectionState.Open)
            {

            }

            string query = "SELECT * FROM artifacts LIMIT 1";

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


                theText.text = dataReader.GetString(1);

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
