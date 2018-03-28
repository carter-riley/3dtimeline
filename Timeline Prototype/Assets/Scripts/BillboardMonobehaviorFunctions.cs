using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BillboardMonobehaviorFunctions : MonoBehaviour {

    public string title;
    public string date;
    public string artifactURL;
    public string description;
    public string artifactType;


    public int boardNumber;
    public string table;
	// Use this for initialization
	void Start () {
        // print("Table is: " + table + ", boardNumber is: " + boardNumber);
        title = FindObjectOfType<NarrativeManager>().titleList[0];
        date = FindObjectOfType<NarrativeManager>().dateList[0];
        artifactURL = FindObjectOfType<NarrativeManager>().urlList[0];
        description = FindObjectOfType<NarrativeManager>().descriptionList[0];
        artifactType = FindObjectOfType<NarrativeManager>().typeList[0];

        // print(date + " " + title);

        FindObjectOfType<NarrativeManager>().titleList.RemoveAt(0);
        FindObjectOfType<NarrativeManager>().dateList.RemoveAt(0);
        FindObjectOfType<NarrativeManager>().urlList.RemoveAt(0);
        FindObjectOfType<NarrativeManager>().typeList.RemoveAt(0);
        FindObjectOfType<NarrativeManager>().descriptionList.RemoveAt(0);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseDown()
    {
        // print("called????");
        //PlayerPrefs.SetInt("billboardNumber", this.gameObject.GetComponent<BillboardMonobehaviorFunctions>().boardNumber);

        // Application.LoadLevel("EventView");


        try
        {
            EventViewData.Title = title;
            EventViewData.Date = date;
            EventViewData.Address = artifactURL;
            EventViewData.Description = description;
            EventViewData.Type = artifactType;


            // PlayerPrefs.SetInt("boardNumber", boardNumber);
            // PlayerPrefs.SetString("table", table);

            PlayerPrefs.SetFloat("xPos", Camera.main.transform.position.x);
            PlayerPrefs.SetFloat("zPos", Camera.main.transform.position.z);

            // DontDestroyOnLoad(gameObject);

            // DontDestroyOnLoad(this.gameObject);
            SceneManager.LoadScene("EventView");
        }
        catch (System.Exception e)
        {
            print("Something went wrong for some reason, maybe this will help: " + e);
        }


    }

    public int getBoardNumber() {
        return boardNumber;
    }

    public string getTable ()
    {
        return table;
    }
}
