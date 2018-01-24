using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardMonobehaviorFunctions : MonoBehaviour {


    public int boardNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("billboardNumber", this.gameObject.GetComponent<BillboardMonobehaviorFunctions>().boardNumber);

        Application.LoadLevel("EventView");
    }
}
