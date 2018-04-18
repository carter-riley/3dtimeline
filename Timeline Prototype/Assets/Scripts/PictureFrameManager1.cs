     using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
using Patagames;

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

        // print(address);

        //if (address != "Null" || address.Contains(".pdf"))
        //{
        //}


        // FindObjectOfType<NarrativeManager>().urlList.RemoveAt(0);
        // FindObjectOfType<NarrativeManager>().typeList.RemoveAt(0);
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


        //if (type == "PDF")
        //{
    

        //    WWW theWebAddress = new WWW(webAddress);
        //    Patagames.Pdf.Net.PdfCommon.Initialize();
        //    var pdf = Patagames.Pdf.Net.PdfDocument.Load(webAddress);
        //    var img = Patagames.Pdf.Net.PdfImageObject.Create(pdf);


        //    byte[] bytes = new byte[img.Bitmap.Width * img.Bitmap.Height * 4];
        //    byte[] copyToBytes = new byte[img.Bitmap.Width * img.Bitmap.Height * 4];
        //    img.Bitmap.FlipXY

        //    // img.Bitmap.Image();

        //    // GetComponent<Renderer>().material.mainTexture = img.Bitmap.Image;
        //    // img.GetBitmap();
        //}
        //else
        //{

        string webAddress = "http://as-dh.gonzaga.edu/omeka/files/original/" + GetComponentInParent<BillboardMonobehaviorFunctions>().thisArtifact.URL;


        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(webAddress);
        yield return www;
        www.LoadImageIntoTexture(tex);

        GetComponent<Renderer>().material.mainTexture = tex;
        // }

        // EventViewData.Picture = tex;


        // FindObjectOfType<NarrativeManager>().pictureCount++;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
