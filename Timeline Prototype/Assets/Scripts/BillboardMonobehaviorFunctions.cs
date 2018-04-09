using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.EventSystems;

public class BillboardMonobehaviorFunctions : MonoBehaviour
{
    bool enter = false;
    public float initialTouch;
    public static int guiDepth = 5;
    public string title;
    public string date;
    public string artifactURL;
    public string description;
    public string artifactType;

    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;

    public int boardNumber;
    public string table;
    // Use this for initialization
    void Start()
    {
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
    void OnGUI()
    {
        GUI.depth = guiDepth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            enter = true;

            //clicked++;
            //if (clicked == 1) clicktime = Time.time;

            //if (clicked > 1 && Time.time - clicktime < clickdelay)
            //{
            //    clicked = 0;
            //    clicktime = 0;
            //    Debug.Log("Double CLick: ");
            //    try
            //    {
            //        EventViewData.Title = title;
            //        EventViewData.Date = date;
            //        EventViewData.Address = artifactURL;
            //        EventViewData.Description = description;
            //        EventViewData.Type = artifactType;


            //        // PlayerPrefs.SetInt("boardNumber", boardNumber);
            //        // PlayerPrefs.SetString("table", table);

            //        PlayerPrefs.SetFloat("xPos", Camera.main.transform.position.x);
            //        PlayerPrefs.SetFloat("zPos", Camera.main.transform.position.z);

            //        // DontDestroyOnLoad(gameObject);

            //        // DontDestroyOnLoad(this.gameObject);
            //        SceneManager.LoadScene("EventView");
            //    }
            //    catch (System.Exception e)
            //    {
            //        print("Something went wrong for some reason, maybe this will help: " + e);
            //    }

            //}
            //else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;



            // print("called????");
            PlayerPrefs.SetInt("billboardnumber", this.gameObject.GetComponent<BillboardMonobehaviorFunctions>().boardNumber);

            Application.LoadLevel("eventview");
            if (enter)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {

                    try
                    {
                        EventViewData.Title = title;
                        EventViewData.Date = date;
                        EventViewData.Address = artifactURL;
                        EventViewData.Description = description;
                        EventViewData.Type = artifactType;


                        // playerprefs.setint("boardnumber", boardnumber);
                        // playerprefs.setstring("table", table);

                        PlayerPrefs.SetFloat("xpos", Camera.main.transform.position.x);
                        PlayerPrefs.SetFloat("zpos", Camera.main.transform.position.z);

                        // dontdestroyonload(gameobject);

                        // dontdestroyonload(this.gameobject);
                        SceneManager.LoadScene("eventview");
                    }
                    catch (System.Exception e)
                    {
                        print("something went wrong for some reason, maybe this will help: " + e);
                    }
                }
            }
        }
    }

    public int getBoardNumber()
    {
        return boardNumber;
    }

    public string getTable()
    {
        return table;
    }
}
