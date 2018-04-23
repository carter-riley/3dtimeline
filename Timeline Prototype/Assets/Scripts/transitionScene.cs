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
        PlayerPrefs.SetFloat("xpos", xPosPhilanthropy);
        PlayerPrefs.SetFloat("zpos", zPosPhilanthropy);
        Application.LoadLevel("TestMode");
        
    }

    public void changeSceneToTimelineViewComingOfAge()
    {
        PlayerPrefs.SetFloat("xpos", xPosComingOfAge);
        PlayerPrefs.SetFloat("zpos", zPosComingOfAge);
        Application.LoadLevel("TestMode");
    }

    public void changeSceneToTimelineViewGonzaga()
    {
        PlayerPrefs.SetFloat("xpos", xPosGonzaga);
        PlayerPrefs.SetFloat("zpos", zPosGonzaga);
        Application.LoadLevel("TestMode");
        
    }

    public void changeSceneToStartScreen()
    {
        Application.LoadLevel("startScreen");

    }
}
