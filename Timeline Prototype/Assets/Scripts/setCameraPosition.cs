using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setCameraPosition : MonoBehaviour {

    public Camera mainCamera;

    int middleOfGonzagaPath;
    int middleOfPhilanthropyPath;
    int middleOfComingOfAgePath;

    public Text philanthropyPathTitle;
    public Text comingOfAgePathTitle;
    public Text gonzagaPathTitle;

    public GameObject gonzagaBlueCircle;
    public GameObject comingOfAgeCircle;
    public GameObject philanthropyCircle;

    void Start () {

        

        //int cameraPosition = PlayerPrefs.GetInt("cameraPosition");
        float cameraXPos = PlayerPrefs.GetFloat("xPos");
        float cameraZPos = PlayerPrefs.GetFloat("zPos");

        mainCamera.transform.position = new Vector3(cameraXPos, 11, cameraZPos); //starting postion

        middleOfGonzagaPath = this.gameObject.GetComponent<JumpNarratives>().gonzagaZLoc;
        middleOfPhilanthropyPath = this.gameObject.GetComponent<JumpNarratives>().philanthropyZLoc;
        middleOfComingOfAgePath = this.gameObject.GetComponent<JumpNarratives>().comingOfAgeZLoc;


        print(middleOfGonzagaPath);
        print(cameraZPos);
        if (cameraZPos == middleOfGonzagaPath || cameraZPos + 1 == middleOfGonzagaPath || cameraZPos - 1 == middleOfGonzagaPath)
        {
            gonzagaPathTitle.gameObject.SetActive(true);

            gonzagaBlueCircle.gameObject.SetActive(true);
            comingOfAgeCircle.gameObject.SetActive(false);
            philanthropyCircle.gameObject.SetActive(false);
        }
        else if (cameraZPos == middleOfPhilanthropyPath || cameraZPos + 1 == middleOfPhilanthropyPath || cameraZPos - 1 == middleOfPhilanthropyPath) {
            philanthropyPathTitle.gameObject.SetActive(true);

            gonzagaBlueCircle.gameObject.SetActive(false);
            comingOfAgeCircle.gameObject.SetActive(false);
            philanthropyCircle.gameObject.SetActive(true);
        } else if(cameraZPos == middleOfComingOfAgePath || cameraZPos + 1 == middleOfComingOfAgePath || cameraZPos - 1 == middleOfComingOfAgePath)
        {
            comingOfAgePathTitle.gameObject.SetActive(true);

            gonzagaBlueCircle.gameObject.SetActive(false);
            comingOfAgeCircle.gameObject.SetActive(true);
            philanthropyCircle.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
