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

        print("Intersection Icon Manager, artifact intersects with: " + intersectingNarrative);

        if (intersectingNarrative.Contains("phil"))
        {
            GetComponent<Renderer>().material.mainTexture = philanthropy;
        }
        else if (intersectingNarrative.Contains("Age"))
        {
            GetComponent<Renderer>().material.mainTexture = comingofAge;
        }
        else if (intersectingNarrative.Contains("zag"))
        {
            GetComponent<Renderer>().material.mainTexture = gonzaga;
        }
        else
        {
            print("Default case, no texture applied");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
