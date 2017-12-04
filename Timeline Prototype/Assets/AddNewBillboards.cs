using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewBillboards : MonoBehaviour {

	public GameObject prefab;
	public int numberOfObjects = 20;
	//public float radius = 5f;

	// Use this for initialization
	void Start () {
		//Billoard clone = (Billoard)Instantiate(projectile, transform.position, transform.rotation);
		//		var gameObject = new GameObject("Billboard");
		//		var meshFilter = gameObject.AddComponent<MeshFilter>();
		//		gameObject.AddComponent<MeshRenderer>();
		for (int i = 0; i < numberOfObjects; i++) {
			//float angle = i * Mathf.PI * 2 / numberOfObjects;
			Vector3 pos = new Vector3(i-(i*80), 0, Random.Range(-60.0f, 60.0f));
			Instantiate(prefab, pos, Quaternion.identity);
		}
		//

	}

	// Update is called once per frame
	void Update () {

	}
}
