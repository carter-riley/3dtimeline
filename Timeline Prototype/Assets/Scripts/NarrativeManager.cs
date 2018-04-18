using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeManager : MonoBehaviour {

    public List<Artifact> artifactList = new List<Artifact>();

    //public List<String> titleList = new List<String>();
    //public List<String> descriptionList = new List<String>();
    //public List<String> dateList = new List<String>();
    //public List<String> typeList = new List<String>();
    //public List<String> urlList = new List<String>();
    //public List<Boolean> intersectionList = new List<Boolean>();

    public int currentNumber = 0;
    public int created = 0;
    // public int pictureCount = 0;
    // public int textCount = 0;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
