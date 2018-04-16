using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour {
    public int ID { get; set; }
    public string Title { get; set; }
    public string Date { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string URL { get; set; }
    public bool IsIntersection { get; set; }
    public string IntersectWith { get; set; }
    public Texture2D Image { get; set; }

    public Artifact(int iD, string title, string date, string description, string type, string uRL, bool isIntersection, string intersectWith, Texture2D image)
    {
        ID = iD;
        Title = title;
        Date = date;
        Description = description;
        Type = type;
        URL = uRL;
        IsIntersection = isIntersection;
        IntersectWith = intersectWith;
        Image = image;
    }

    public Artifact()
    {
        ID = 0;
        Title = "Blank";
        Date = "0 AD";
        Description = "Something happened";
        Type = "Null";
        URL = "www.google.com";
        IsIntersection = false;
        IntersectWith = "Nothing";
    }

    public override string ToString()
    {
        return this.ID + " " + this.Title + " " + this.Date + " " + this.Description + " " + this.Type + " " + this.URL + " " + this.IsIntersection + " " + this.Image.ToString();
    }
}
