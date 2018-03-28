using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BillboardMonobehaviorFunctions : MonoBehaviour {


    public int boardNumber;
    public string table;
	// Use this for initialization
	void Start () {
        // print("Table is: " + table + ", boardNumber is: " + boardNumber);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        print("called????");
        //PlayerPrefs.SetInt("billboardNumber", this.gameObject.GetComponent<BillboardMonobehaviorFunctions>().boardNumber);

        // Application.LoadLevel("EventView");

        PlayerPrefs.SetInt("boardNumber", boardNumber);
        PlayerPrefs.SetString("table", table);

        PlayerPrefs.SetFloat("xPos", Camera.main.transform.position.x);
        PlayerPrefs.SetFloat("zPos", Camera.main.transform.position.z);

        // DontDestroyOnLoad(gameObject);

        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("EventView");

    }

    public int getBoardNumber() {
        return boardNumber;
    }

    public string getTable ()
    {
        return table;
    }
}
