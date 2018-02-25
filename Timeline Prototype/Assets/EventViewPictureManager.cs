using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventViewPictureManager : MonoBehaviour {

    public GameObject Image;
    public MeshRenderer URL;

    public string webAddress;

    // Use this for initialization
    IEnumerator Start () {
        webAddress = "http://placecorgi.com/250";

        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(webAddress);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Image>().material.mainTexture = tex;
        // GetComponent<Renderer>().material.mainTexture = tex;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
