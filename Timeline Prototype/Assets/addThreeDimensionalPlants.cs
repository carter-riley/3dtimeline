using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addThreeDimensionalPlants : MonoBehaviour {

    public int xLengthFlowers;

    public int xStartFlowers;
    public float yStartFlowers;

    public int zStartGonzagaLeftFlowers;
    public int zStartGonzagaRightFlowers;
    public int zStartPhilanthropyLeftFlowers;
    public int zStartPhilanthropyRightFlowers;
    public int zStartComingOfAgeLeftFlowers;
    public int zStartComingOfAgeRightFlowers;

    public GameObject flowerPot;
    public GameObject bluePlants;
    public GameObject yellowPlants;

    // Use this for initialization
    void Start() {

        for (int i = 0; i < xLengthFlowers; i += 20) {
            Vector3 gonzagaLeftPos = new Vector3(xStartFlowers + i, yStartFlowers, zStartGonzagaLeftFlowers);
            GameObject newGonzagaLeftFlower = Instantiate(flowerPot, gonzagaLeftPos, Quaternion.identity);
            DontDestroyOnLoad(newGonzagaLeftFlower);

            Vector3 gonzagaRightPos = new Vector3(xStartFlowers + i, yStartFlowers, zStartGonzagaRightFlowers);
            GameObject newGonzagaRightFlower = Instantiate(flowerPot, gonzagaRightPos, Quaternion.identity);
            DontDestroyOnLoad(newGonzagaRightFlower);


            Vector3 philanthropyLeftPos = new Vector3(xStartFlowers + i, yStartFlowers, zStartPhilanthropyLeftFlowers);
            GameObject newPhilanthropyLeftFlower = Instantiate(bluePlants, philanthropyLeftPos, Quaternion.identity);
            DontDestroyOnLoad(newPhilanthropyLeftFlower);



            Vector3 philanthropyRightPos = new Vector3(xStartFlowers + i, yStartFlowers, zStartPhilanthropyRightFlowers);
            GameObject newPhilanthropyRightFlower = Instantiate(bluePlants, philanthropyRightPos, Quaternion.identity);
            DontDestroyOnLoad(newPhilanthropyRightFlower);


            Vector3 comingOfAgeLeftPos = new Vector3(xStartFlowers + (i - ((i/20) * 5)), yStartFlowers, zStartComingOfAgeLeftFlowers);
            GameObject newComingOfAgeLeftFlower = Instantiate(yellowPlants, comingOfAgeLeftPos, Quaternion.identity);
            DontDestroyOnLoad(newComingOfAgeLeftFlower);


            Vector3 comingOfAgeRightPos = new Vector3(xStartFlowers + (i - ((i/20)*5)), yStartFlowers, zStartComingOfAgeRightFlowers);
            GameObject newComingOfAgeRightFlower = Instantiate(yellowPlants, comingOfAgeRightPos, Quaternion.identity);
            DontDestroyOnLoad(newComingOfAgeRightFlower);

            Vector3 flowerScale = new Vector3(15, 15, 15);

            newGonzagaLeftFlower.transform.localScale = flowerScale;
            newGonzagaRightFlower.transform.localScale = flowerScale;
            newPhilanthropyLeftFlower.transform.localScale = flowerScale;
            newPhilanthropyRightFlower.transform.localScale = flowerScale;
            newComingOfAgeLeftFlower.transform.localScale = flowerScale;
            newComingOfAgeRightFlower.transform.localScale = flowerScale;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
