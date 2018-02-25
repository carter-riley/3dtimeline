using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;

public class EventViewPictureManager : MonoBehaviour
{

    public GameObject pictureFrame;
    public MeshRenderer URL;

    public string webAddress;

    IEnumerator Start()
    {

        int boardNumber = PlayerPrefs.GetInt("boardNumber") + 1;

        string table = PlayerPrefs.GetString("table");

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

            // GameObject parentObject = base.gameObject;

            // BillboardMonobehaviorFunctions monobehaviorFunctionsScript = this.GetComponentInParent<BillboardMonobehaviorFunctions>();
            // int newBoardNumber = monobehaviorFunctionsScript.boardNumber + 1;


            // string currentNarrative = monobehaviorFunctionsScript.table;

            string query = "SELECT * FROM " + table + " WHERE Number = " + boardNumber;

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
                if (dataReader.GetString(4) == "Video")
                {
                    webAddress = dataReader.GetString(7);
                    // StreamVideo.playVideo(dataReader.GetString(7));
                }
                else
                {
                    // theText.text = dataReader["Record_id"];
                    try
                    {
                        webAddress = "http://as-dh.gonzaga.edu/omeka/files/original/" + dataReader.GetString(7);

                    }
                    catch
                    {
                        if (boardNumber % 3 == 0)
                        {
                            webAddress = "http://grfx.cstv.com/photos/schools/gonz/sports/genrel/auto_original/8870368.jpeg";
                        }
                        else if (boardNumber % 3 == 1)
                        {
                            webAddress = "http://grfx.cstv.com/photos/schools/gonz/sports/genrel/auto_original/8870367.jpeg";
                        }
                        else if (boardNumber % 3 == 2)
                        {
                            webAddress = "http://grfx.cstv.com/schools/gonz/graphics/auto/GUBulldogWallpaper1024x768.jpg";
                        }
                    }
                }


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
            print("File: EventViewPictureManager.cs. Exception: + " + ex);
        }

        // print(webAddress);

        Texture2D tex;
        tex = new Texture2D(128, 128);
        WWW www = new WWW(webAddress);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Image>().material.mainTexture = tex;

        // print("Texture: x = " + tex.width + ", y = " + tex.height);
        // print("Texture ratio is " + tex.width/tex.height);

        int aspectRatio = tex.width / tex.height;

        // GetComponent<Transform>().localScale.Scale(new Vector3(0F, 1F, 0.05F));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
