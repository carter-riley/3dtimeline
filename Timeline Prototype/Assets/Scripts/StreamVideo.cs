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
        isVideo = false;
        try
        {
            MySqlConnection connect;
            //Connection string for Connector/ODBC 3.51
            // Driver={MariaDB ODBC 3.0 Driver};
            string MyConString = "Server=147.222.163.1;UID=sdg7;Database=sdg7_DB;PWD=3dTimeline;Port=3306";

            connect = new MySql.Data.MySqlClient.MySqlConnection();

            connect.ConnectionString = MyConString;

            connect.Open();

            if (connect.State == ConnectionState.Open)
            {

            }

            GameObject parentObject = base.gameObject;

            BillboardMonobehaviorFunctions monobehaviorFunctionsScript = this.GetComponentInParent<BillboardMonobehaviorFunctions>();
            int newBoardNumber = monobehaviorFunctionsScript.boardNumber + 1;


            string currentNarrative = monobehaviorFunctionsScript.table;

            string query = "SELECT * FROM " + currentNarrative + " WHERE Number = " + newBoardNumber;

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection

            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connect);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                if (dataReader.GetString(4) == "Video")
                {
                    // videoURL = dataReader.GetString(7);
                    videoURL = "http://as-dh.gonzaga.edu/omeka/files/original/" + dataReader.GetString(7);

                    isVideo = true;
                    // StreamVideo.playVideo(dataReader.GetString(7));
                }
            }

            //close Data Reader                
            dataReader.Close();
            connect.Close();

            // Console.ReadKey();

        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {

        }

        if (isVideo) {
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