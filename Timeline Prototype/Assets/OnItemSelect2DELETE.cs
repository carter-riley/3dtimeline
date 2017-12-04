using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OnItemSelect2Delete : MonoBehaviour {
	
	public CanvasGroup hintText;
	// Use this for initialization
	void Start () {
		//Debug.Log("Loaded");
		hintText.alpha = 0f;
		hintText.interactable = false;
		hintText.blocksRaycasts = false;
	}

	// Update is called once per frame
	void Update () {

	}


	void OnMouseDown()
	{
		PlayerPrefs.SetInt ("billboardNumber", 1);


		#pragma warning disable CS0618 // Type or member is obsolete
		Application.LoadLevel("EventView");
		#pragma warning restore CS0618 // Type or member is obsolete
		//Debug.Log("It Works");
		//SceneManager.LoadScene("EventView")

	}

	void OnMouseEnter()
	{
		hintText.alpha = 1;
	}

	private void OnMouseExit()
	{
		hintText.alpha = 0f;
	}
}