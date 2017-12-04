using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayback : MonoBehaviour {

    public GameObject TV;
    public MovieTexture movie;
    private AudioSource audio;


    // Use this for initialization
    void Start () {

        MovieTexture movie = (MovieTexture)TV.GetComponent<Renderer>().material.mainTexture;

        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && movie.isPlaying)  // Used to pause video playback with the spacebar
        {
            movie.Pause();
        }

        else if (Input.GetKeyDown(KeyCode.Space) && !movie.isPlaying) // Used to play the video after it has been paused
        {
            movie.Play();
        }

    }
}
