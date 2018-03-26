 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;

public class PictureFrameManager1 : MonoBehaviour
{

    public GameObject pictureFrame;
    public MeshRenderer URL;

    public string webAddress;

    IEnumerator Start()
    {
        // int count = FindObjectOfType<NarrativeManager>().pictureCount;
        // print("Picture frame manager, current title is: " + FindObjectOfType<NarrativeManager>().titleList[0]);
        // print("URL is: " + FindObjectOfType<NarrativeManager>().urlList[0]);

        // print(webAddress);

        // print(FindObjectOfType<NarrativeManager>().urlList[0]);

        if (FindObjectOfType<NarrativeManager>().urlList[0] != "Null" || FindObjectOfType<NarrativeManager>().urlList[0].Contains(".pdf"))
        {
            webAddress = "http://as-dh.gonzaga.edu/omeka/files/original/" + FindObjectOfType<NarrativeManager>().urlList[0];
        }
        FindObjectOfType<NarrativeManager>().urlList.RemoveAt(0);
        FindObjectOfType<NarrativeManager>().typeList.RemoveAt(0);
        /*
        if (FindObjectOfType<NarrativeManager>().typeList[0] == "Video")
        {
            webAddress = "http://as-dh.gonzaga.edu/omeka/files/original/" + FindObjectOfType<NarrativeManager>().urlList[0];
            // StreamVideo.playVideo(dataReader.GetString(7));
        }
        else
        {
            try
            {
                webAddress = "http://as-dh.gonzaga.edu/omeka/files/original/" + FindObjectOfType<NarrativeManager>().urlList[0];
            }
            catch
            {
                print("Picture at " + count + "does not have a picture associated with it or is a pdf");
            }
        }
        */

        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(webAddress);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Renderer>().material.mainTexture = tex;


        // FindObjectOfType<NarrativeManager>().pictureCount++;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
