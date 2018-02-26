using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageViewPictureManager : MonoBehaviour {

    public GameObject pictureFrame;
    public MeshRenderer URL;

    public string webAddress;

    // Use this for initialization
    IEnumerator Start () {
        string URL = PlayerPrefs.GetString("URL");

        Texture2D tex;
        tex = new Texture2D(128, 128);
        WWW www = new WWW(URL);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Image>().material.mainTexture = tex;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
