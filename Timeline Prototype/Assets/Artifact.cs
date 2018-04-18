using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact {
    public string Title { get; set; }
    public string Date { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string URL { get; set; }
    public bool IsIntersection { get; set; }
    public string IntersectWith { get; set; }
    public Texture2D Image { get; set; }
    public string Table { get; set; }

    public Artifact(string title, string date, string description, string type, string uRL, bool isIntersection, string intersectWith, Texture2D image, string table)
    {
        Title = title;
        Date = date;
        Description = description;
        Type = type;
        URL = uRL;
        IsIntersection = isIntersection;
        IntersectWith = intersectWith;
        Image = image;
        Table = table;
    }

    public Artifact(string title, string date, string description, string type, string uRL, string table)
    {
        Title = title;
        Date = date;
        Description = description;
        Type = type;
        URL = uRL;
        Table = table;
    }

    public Artifact()
    {
        Title = "Blank";
        Date = "0 AD";
        Description = "Something happened";
        Type = "Null";
        URL = "www.google.com";
        IsIntersection = false;
        IntersectWith = "Nothing";
        Image = null;
        Table = "Null";
    }

    public override string ToString()
    {
        return this.Title + " " + this.Date + " " + this.Description + " " + this.Type + " " + this.URL + " " + this.IsIntersection + " " + this.Image.ToString() + " " + this.Table;
    }
}
