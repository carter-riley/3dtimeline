using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BillboardMonobehaviorFunctions : MonoBehaviour
{
    bool enter = false;
    public float initialTouch;
    public static int guiDepth = 5;
    //public string title;
    //public string date;
    //public string artifactURL;
    //public string description;
    //public string artifactType;
    //public bool isIntersection;
    //public string webAddress;
    public Artifact thisArtifact;

    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;

    public int boardNumber;
    public string table;
    // Use this for initialization
    IEnumerator Start()
    {
        thisArtifact = FindObjectOfType<NarrativeManager>().artifactList[0];
        FindObjectOfType<NarrativeManager>().artifactList.RemoveAt(0);


        if(thisArtifact.URL == null) {

        } else if (thisArtifact.URL.Contains(".mp4"))
        {
            Texture2D tex = null;
            thisArtifact.Image = tex;
        } else if(thisArtifact.URL.Contains(".png") || thisArtifact.URL.Contains(".jpg"))
        {
            Texture2D tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
            WWW www = new WWW("http://as-dh.gonzaga.edu/omeka/files/original/" + thisArtifact.URL);
            yield return www;
            www.LoadImageIntoTexture(tex);

            thisArtifact.Image = tex;
        } else if(thisArtifact.URL.Contains(".pdf"))
        {


        }





        // Texture2D tex = CreateTexture.PictureTexture(artifactURL);
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
        //if (!EventSystem.current.IsPointerOverGameObject())
        //{
            enter = true;

        clicked++;
        if (clicked == 1) clicktime = Time.time;

        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            Debug.Log("double click: ");


            EventViewData.TheArtifact = thisArtifact;


            //playerPrefs.setint("boardnumber", boardnumber);
            //playerPrefs.setstring("table", table);

            PlayerPrefs.SetFloat("xpos", Camera.main.transform.position.x);
            PlayerPrefs.SetFloat("zpos", Camera.main.transform.position.z);

            // dontdestroyonload(gameobject);

            // dontdestroyonload(this.gameobject);
            SceneManager.LoadScene("eventview");

        }
        else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;



        // print("called????");
        PlayerPrefs.SetInt("billboardnumber", this.gameObject.GetComponent<BillboardMonobehaviorFunctions>().boardNumber);

     /*       Application.LoadLevel("eventview");
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
            }*/
       // }
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
