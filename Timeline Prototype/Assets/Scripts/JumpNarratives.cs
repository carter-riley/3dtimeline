using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpNarratives : MonoBehaviour {

    public int gonzagaZLoc;
    public int philanthropyZLoc;
    public int comingOfAgeZLoc;

    public Text philanthropyPathTitle;
    public Text comingOfAgePathTitle;
    public Text gonzagaPathTitle;

    public void JumpToGonzaga()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, gonzagaZLoc);
        gonzagaPathTitle.gameObject.SetActive(true);
        philanthropyPathTitle.gameObject.SetActive(false);
        comingOfAgePathTitle.gameObject.SetActive(false);
    }

    public void JumpToPhilanthropy()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, philanthropyZLoc);
        philanthropyPathTitle.gameObject.SetActive(true);
        gonzagaPathTitle.gameObject.SetActive(false);
        comingOfAgePathTitle.gameObject.SetActive(false);
    }

    public void JumpToComingOfAge() {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, comingOfAgeZLoc);
        comingOfAgePathTitle.gameObject.SetActive(true);
        gonzagaPathTitle.gameObject.SetActive(false);
        philanthropyPathTitle.gameObject.SetActive(false);
    }

    

    public void ResetToStart()
    {
        Camera.main.transform.position = new Vector3(-50, 11, Camera.main.transform.position.z);
    }
}
