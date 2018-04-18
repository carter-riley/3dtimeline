using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


/// <summary>
/// Unity VideoPlayer Script for Unity 5.6 (currently in beta 0b11 as of March 15, 2017)
/// Blog URL: http://justcode.me/unity2d/how-to-play-videos-on-unity-using-new-videoplayer/
/// YouTube Video Link: https://www.youtube.com/watch?v=nGA3jMBDjHk
/// StackOverflow Disscussion: http://stackoverflow.com/questions/41144054/using-new-unity-videoplayer-and-videoclip-api-to-play-video/
/// Code Contiburation: StackOverflow - Programmer
/// </summary>


public class StreamVideo2 : MonoBehaviour
{

    public RawImage image;
    public GameObject playIcon;

    public VideoClip videoToPlay;
    public RenderTexture targetTexture;
    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    private AudioSource audioSource;

    private bool isPaused = false;
    private bool firstRun = true;
    private bool isVideo;


    void Start()
    {

        // print("Address contains MP4: " + EventViewData.Address + " " + EventViewData.Address.Contains(".mp4"));

        if (EventViewData.TheArtifact.URL.Contains(".mp4"))
        {

            //image.RawImage = video; //Video component is enabled
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator playVideo()
    {
        playIcon.SetActive(false);
        firstRun = false;
        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        audioSource.Pause();

        //We want to play from video clip not from url

        //videoPlayer.source = VideoSource.VideoClip;

        // Vide clip from Url
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = "http://as-dh.gonzaga.edu/omeka/files/original/" + EventViewData.TheArtifact.URL;

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        //targetTexture = frame = 0;

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        //videoPlayer.loopPointReached += EndReached;

        //Wait until video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        Debug.Log("Done Preparing Video");

        //Assign the Texture from Video to RawImage to be displayed
        image.texture = videoPlayer.texture;

        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();

        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying)
        {
            Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }

        Debug.Log("Done Playing Video");
    }

    /*
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Reset video to first frame
        videoPlayer.frame = 0;
    }
    */

    public void PlayPause()
    {
        if (!firstRun && !isPaused)
        {
            videoPlayer.Pause();
            audioSource.Pause();
            playIcon.SetActive(true);
            isPaused = true;
        }
        else if (!firstRun && isPaused)
        {
            videoPlayer.Play();
            audioSource.Play();
            playIcon.SetActive(false);
            isPaused = false;
        }
        else
        {
            StartCoroutine(playVideo());
        }
    }
}