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

        string address = EventViewData.Address;

        // print(webAddress);


        if(address == "Null")
        {
            webAddress = "http://placecorgi.com/260";
        } else
        {
            webAddress = "http://as-dh.gonzaga.edu/omeka/files/original/" + address;

        }



        Texture2D tex;
        tex = new Texture2D(128, 128);
        WWW www = new WWW(webAddress);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Image>().material.mainTexture = tex;

        webAddress = "http://placecorgi.com/260";


        Texture2D tex2;
        tex2 = new Texture2D(128, 128);
        WWW www2 = new WWW(webAddress);
        yield return www2;
        www2.LoadImageIntoTexture(tex2);
        GetComponent<Image>().material.mainTexture = tex2;

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
