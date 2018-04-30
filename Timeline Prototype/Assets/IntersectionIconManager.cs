using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionIconManager : MonoBehaviour
{

    public Texture comingofAge;
    public Texture philanthropy;
    public Texture gonzaga;

    // Use this for initialization
    void Start()
    {

        string intersectingNarrative = GetComponentInParent<BillboardMonobehaviorFunctions>().thisArtifact.IntersectWith;


        switch (intersectingNarrative)
        {
            case "philanthropy":
                GetComponent<Renderer>().material.mainTexture = philanthropy;
                break;
            case "comingofAge":
                GetComponent<Renderer>().material.mainTexture = comingofAge;
                break;
            case "gonzaga":
                GetComponent<Renderer>().material.mainTexture = gonzaga;
                break;
            default:
                print("Default case, no texture applied");
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
