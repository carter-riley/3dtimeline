using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createPath : MonoBehaviour {

    public int xLength;
    public int yLength;
    public int zLength;

    public int xStart;
    public int yStart;
    public int zStart;

	// Use this for initialization
	void Start () {
        Vector3 scale = new Vector3(xLength, yLength, zLength);
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.localScale = scale;
        plane.transform.position = new Vector3(xStart, yStart, zStart);

      //Texture2D tex = Resources.Load("Bricks Texture 07 normal") as Texture2D;
      //Renderer planeRenderer = plane.GetComponent<Renderer>();
      //planeRenderer.material.mainTexture = tex;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
