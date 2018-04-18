using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // GetComponent<Image>().material.color = Color.white;
        // GetComponent<Canvas>
        GetComponent<CanvasRenderer>().SetColor(Color.white);

        if(GetComponent<Material>() != null)
        {
            GetComponent<Material>().mainTexture = null;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
