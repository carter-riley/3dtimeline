using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageViewPictureManager : MonoBehaviour {

    public GameObject pictureFrame;
    public MeshRenderer URL;

    public string webAddress;

    // Use this for initialization
    void Start () {

        Texture2D tex = EventViewData.TheArtifact.Image;

        GetComponent<Image>().material.mainTexture = tex;

        tex = null;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
