using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionScene : MonoBehaviour {

    public int xPosPhilanthropy;
    public int zPosPhilanthropy;

    public int xPosComingOfAge;
    public int zPosComingOfAge;

    public int xPosGonzaga;
    public int zPosGonzaga;

    public void changeSceneToTimelineViewPhilanthropy() {
        PlayerPrefs.SetFloat("xPos", xPosPhilanthropy);
        PlayerPrefs.SetFloat("zPos", zPosPhilanthropy);
        Application.LoadLevel("TestMode");
        
    }

    public void changeSceneToTimelineViewComingOfAge()
    {
        PlayerPrefs.SetFloat("xPos", xPosComingOfAge);
        PlayerPrefs.SetFloat("zPos", zPosComingOfAge);
        Application.LoadLevel("TestMode");
    }

    public void changeSceneToTimelineViewGonzaga()
    {
        PlayerPrefs.SetFloat("xPos", xPosGonzaga);
        PlayerPrefs.SetFloat("zPos", zPosGonzaga);
        Application.LoadLevel("TestMode");
        
    }
}
