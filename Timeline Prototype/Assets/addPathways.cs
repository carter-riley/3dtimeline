using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addPathways : MonoBehaviour {

    public int xScaleGonzaga;
    public int yScaleGonzaga;
    public int zScaleGonzaga;

    public int xStartGonzaga;
    public float yStartGonzaga;
    public int zStartGonzaga;

    public Material gonzagaMaterial;



    public int xScalePhilanthropy;
    public int yScalePhilanthropy;
    public int zScalePhilanthropy;

    public int xStartPhilanthropy;
    public float yStartPhilanthropy;
    public int zStartPhilanthropy;

    public Material philanthropyMaterial;



    public int xScaleComingOfAge;
    public int yScaleComingOfAge;
    public int zScaleComingOfAge;

    public int xStartComingOfAge;
    public float yStartComingOfAge;
    public int zStartComingOfAge;

    public Material comingOfAgeMaterial;



    public GameObject planeGonzaga;
    public GameObject planePhilanthropy;
    public GameObject planeComingOfAge;

    public int xScaleFlowers;
    public int yScaleFlowers;
    public int zScaleFlowers;

    public int xStartFlowers;
    public float yStartFlowers;

    public int zStartGonzagaLeftFlowers;
    public int zStartGonzagaRightFlowers;
    public int zStartPhilanthropyLeftFlowers;
    public int zStartPhilanthropyRightFlowers;
    public int zStartComingOfAgeLeftFlowers;
    public int zStartComingOfAgeRightFlowers;
    
    public Material flowerMaterial;

    public GameObject gonzagaLeftFlowers;
    public GameObject gonzagaRightFlowers;
    public GameObject philanthropyLeftFlowers;
    public GameObject philanthropyRightFlowers;
    public GameObject comingOfAgeLeftFlowers;
    public GameObject comingOfAgeRightFlowers;

    // Use this for initialization
    void Start () {
        Vector3 gonzagaScale = new Vector3(xScaleGonzaga, yScaleGonzaga, zScaleGonzaga);
        planeGonzaga = GameObject.CreatePrimitive(PrimitiveType.Plane);
        planeGonzaga.transform.transform.localScale = gonzagaScale;
        planeGonzaga.transform.position = new Vector3(xStartGonzaga, yStartGonzaga, zStartGonzaga);
        planeGonzaga.GetComponent<Renderer>().material = gonzagaMaterial;

        Vector3 philanthropyScale = new Vector3(xScalePhilanthropy, yScalePhilanthropy, zScalePhilanthropy);
        planePhilanthropy = GameObject.CreatePrimitive(PrimitiveType.Plane);
        planePhilanthropy.transform.transform.localScale = philanthropyScale;
        planePhilanthropy.transform.position = new Vector3(xStartPhilanthropy, yStartPhilanthropy, zStartPhilanthropy);
        planePhilanthropy.GetComponent<Renderer>().material = philanthropyMaterial;

        Vector3 comingOfAgeScale = new Vector3(xScaleComingOfAge, yScaleComingOfAge, zScaleComingOfAge);
        planeComingOfAge = GameObject.CreatePrimitive(PrimitiveType.Plane);
        planeComingOfAge.transform.transform.localScale = comingOfAgeScale;
        planeComingOfAge.transform.position = new Vector3(xStartComingOfAge, yStartComingOfAge, zStartComingOfAge);
        planeComingOfAge.GetComponent<Renderer>().material = comingOfAgeMaterial;

        //Vector3 flowerScale = new Vector3(xScaleFlowers, yScaleFlowers, zScaleFlowers);
        //gonzagaLeftFlowers = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //gonzagaRightFlowers = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //philanthropyLeftFlowers = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //philanthropyRightFlowers = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //comingOfAgeLeftFlowers = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //comingOfAgeRightFlowers = GameObject.CreatePrimitive(PrimitiveType.Plane);

        //gonzagaLeftFlowers.transform.localScale = flowerScale;
        //gonzagaRightFlowers.transform.localFScale = flowerScale;
        //philanthropyLeftFlowers.transform.localScale = flowerScale;
        //philanthropyRightFlowers.transform.localScale = flowerScale;
        //comingOfAgeLeftFlowers.transform.localScale = flowerScale;
        //comingOfAgeRightFlowers.transform.localScale = flowerScale;

        //gonzagaLeftFlowers.transform.position = new Vector3(xStartFlowers, yStartFlowers, zStartGonzagaLeftFlowers);
        //gonzagaRightFlowers.transform.position = new Vector3(xStartFlowers, yStartFlowers, zStartGonzagaRightFlowers);
        //philanthropyLeftFlowers.transform.position = new Vector3(xStartFlowers, yStartFlowers, zStartPhilanthropyLeftFlowers);
        //philanthropyRightFlowers.transform.position = new Vector3(xStartFlowers, yStartFlowers, zStartPhilanthropyRightFlowers);
        //comingOfAgeLeftFlowers.transform.position = new Vector3(xStartFlowers, yStartFlowers, zStartComingOfAgeLeftFlowers);
        //comingOfAgeRightFlowers.transform.position = new Vector3(xStartFlowers, yStartFlowers, zStartComingOfAgeRightFlowers);

        //gonzagaLeftFlowers.GetComponent<Renderer>().material = flowerMaterial;
        //gonzagaRightFlowers.GetComponent<Renderer>().material = flowerMaterial;
        //philanthropyLeftFlowers.GetComponent<Renderer>().material = flowerMaterial;
        //philanthropyRightFlowers.GetComponent<Renderer>().material = flowerMaterial;
        //comingOfAgeLeftFlowers.GetComponent<Renderer>().material = flowerMaterial;
        //comingOfAgeRightFlowers.GetComponent<Renderer>().material = flowerMaterial;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
