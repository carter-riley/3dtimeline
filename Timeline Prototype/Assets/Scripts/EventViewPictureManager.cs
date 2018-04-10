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

    void Start()
    {



        //Texture2D tex;
        //tex = new Texture2D(128, 128);
        //WWW www = new WWW(webAddress);
        //yield return www;
        //www.LoadImageIntoTexture(tex);

        Texture2D tex = EventViewData.Picture;

        GetComponent<Image>().material.mainTexture = tex;

        // print("Texture: x = " + tex.width + ", y = " + tex.height);
        // print("Texture ratio is " + tex.width/tex.height);

        // int aspectRatio = tex.width / tex.height;

        // PlayerPrefs.SetString("URL", webAddress);

        // GetComponent<Transform>().localScale.Scale(new Vector3(0F, 1F, 0.05F));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
