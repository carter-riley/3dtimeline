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
        int count = FindObjectOfType<NarrativeManager>().count;


        // print(webAddress);

        if (FindObjectOfType<NarrativeManager>().typeList[count] == "Video")
        {
            webAddress = "http://as-dh.gonzaga.edu/omeka/files/original/" + FindObjectOfType<NarrativeManager>().urlList[count];
            // StreamVideo.playVideo(dataReader.GetString(7));
        }
        else
        {
            // theText.text = dataReader["Record_id"];
            try
            {
                webAddress = "http://as-dh.gonzaga.edu/omeka/files/original/" + FindObjectOfType<NarrativeManager>().urlList[count];

            }
            catch
            {

            }
        }

        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(webAddress);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Renderer>().material.mainTexture = tex;

        // print("Texture: x = " + tex.width + ", y = " + tex.height);
        // print("Texture ratio is " + tex.width/tex.height);

        // int aspectRatio = tex.width / tex.height;

        // GetComponent<Transform>().localScale.Scale(new Vector3(0F, 1F, 0.05F));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
