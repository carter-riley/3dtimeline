﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewBillboards : MonoBehaviour {

	public GameObject prefab;
	public int numberOfObjects = 20;
    //public float radius = 5f;

    public List<GameObject> billboardsList = new List<GameObject>();

	// Use this for initialization
	void Start () {
        bool left = true;
        float xPosition;
        for (int i = 0; i < numberOfObjects; i++)
        {
            if (left)
            {
                xPosition = -25f;
                left = false;
            }
            else
            {
                xPosition = 125f;
                left = true;
            }


            Vector3 pos = new Vector3(i - (i * 200), 0, xPosition);
            GameObject newBillboard = Instantiate(prefab, pos, Quaternion.identity);
            newBillboard.transform.localScale = new Vector3(0.1F, 0.1F, 0.1F);
            newBillboard.GetComponent<BillboardMonobehaviorFunctions>().boardNumber = billboardsList.Count;


            billboardsList.Add(newBillboard);
        }

	}

	// Update is called once per frame
	void Update () {

	}
}
