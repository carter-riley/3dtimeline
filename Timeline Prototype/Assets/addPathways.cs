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

        //TODO: CREATE AND CALL FUNCTION TO ADD ROW OF FLOWERS NEXT TO SIDES OF PATHS
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
