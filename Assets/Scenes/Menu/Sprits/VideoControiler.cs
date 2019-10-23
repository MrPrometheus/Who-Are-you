using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControiler : MonoBehaviour
{
    public GameObject LoadText;
    public GameObject menu;

    private VideoPlayer videoPlayer;
    private bool isOnce = false;

    public object SceneManeger { get; private set; }

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.skipOnDrop = false;
        videoPlayer.Prepare();
        StartCoroutine(StartVideo());
    }

    IEnumerator StartVideo()
    {
        while (!videoPlayer.isPrepared) yield return null;
        videoPlayer.Play();
        LoadText.SetActive(false);
    }
    
    void Update()
    {
        if ((float) videoPlayer.time > 11.93f && !isOnce)
        {
            videoPlayer.Pause();
            menu.SetActive(true);
            isOnce = true;
        }
        if (videoPlayer.time > 20 && !videoPlayer.isPlaying)
        {
            LoadFirsScene();
        }
    }

    public void LoadFirsScene()
    {
        ReloadDoor.isTeleportToPoint = true;
        SceneManager.LoadSceneAsync("bashnya");
    }

    public void OnClickButton()
    {
        menu.SetActive(false);
        videoPlayer.Play();
    }
}
