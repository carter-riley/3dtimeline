using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager2 : MonoBehaviour
{

    public GameObject textBox;

    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;

    //public PlayerController PlayerCamera;

    // Use this for initialization
    void Start()
    {
        //PlayerController = FindObjectOfType<PlayerController>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

    }

    void Update()
    {
        theText.text = textLines[currentLine];

        if(Input.GetKeyDown(KeyCode.Keypad2))  //allows user to cycle through text on billboard
        {
            currentLine += 1;
        }

        if(currentLine > endAtLine) //Turns text box off at last line of text
        {
            textBox.SetActive(false);
        }
    }
}
