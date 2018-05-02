using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using MySql.Data.MySqlClient;
using System.Data;


/// <summary>
/// Unity VideoPlayer Script for Unity 5.6 (currently in beta 0b11 as of March 15, 2017)
/// Blog URL: http://justcode.me/unity2d/how-to-play-videos-on-unity-using-new-videoplayer/
/// YouTube Video Link: https://www.youtube.com/watch?v=nGA3jMBDjHk
/// StackOverflow Disscussion: http://stackoverflow.com/questions/41144054/using-new-unity-videoplayer-and-videoclip-api-to-play-video/
/// Code Contiburation: StackOverflow - Programmer
/// </summary>


public class StreamVideo : MonoBehaviour
{
    public GameObject pictureFrame;

    public RawImage image;

    public VideoClip videoToPlay;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    private AudioSource audioSource;
    bool isVideo;

    public string videoURL;

    // Use this for initialization
    void Start()
    {

        string address = GetComponentInParent<BillboardMonobehaviorFunctions>().thisArtifact.URL;

        videoURL = "http://as-dh.gonzaga.edu/omeka/files/original/" + address;

        if (videoURL.Contains(".mp4")) {
            Application.runInBackground = true;
            StartCoroutine(playVideo(videoURL));
        }
    }

    public IEnumerator playVideo(string url)
    {

        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        //audioSource.Pause();

        //We want to play from video clip not from url

        //videoPlayer.source = VideoSource.VideoClip;

        // Vide clip from Url
        videoPlayer.source = VideoSource.Url;
        // videoPlayer.url = "http://as-dh.gonzaga.edu/omeka/files/original/e6647e31afaaa530789fa209e03f865b.mp4";
        videoPlayer.url = url;

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        //Wait until video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        Debug.Log("Done Preparing Video");

        //Assign the Texture from Video to RawImage to be displayed
        //image.texture = videoPlayer.texture;

        //Play Video
        videoPlayer.Pause();

        //Play Sound
        audioSource.Pause();

        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying)
        {
            Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }

        Debug.Log("Done Playing Video");
    }

    public void Seek(int frame)
    {
        videoPlayer.frame = frame;
    }


    // Update is called once per frame
    void Update()
    {
        if (isVideo)
        {
            if (Input.GetKeyDown(KeyCode.Space) && videoPlayer.isPlaying)  // Used to pause video playback with the spacebar
            {
                videoPlayer.Pause();
            }

            else if (Input.GetKeyDown(KeyCode.Space) && !videoPlayer.isPlaying) // Used to play the video after it has been paused
            {
                videoPlayer.Play();
            }
        }
    }
}