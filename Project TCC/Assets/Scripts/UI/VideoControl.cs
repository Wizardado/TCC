using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    [Header("Overall control")]
    public int cutSceneNow;
    public bool playingVideo;
    public float waitTime = 0;

    [Header("Cutscenes audios and clips")]
    public VideoClip[] cutscenesVideos;
    public AudioClip[] cutsceneAudioList;
    public VideoPlayer cutscenesPlayer;
    public AudioSource cutsceneAudio;

    private UIControl uiControl;

    void Start()
    {
        uiControl = GetComponent<UIControl>(); 
    }

    void Update()
    {
        if(!playingVideo)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndVideo();
        }
    }

    public void PlayVideo()
    {
        playingVideo = true;
        cutscenesPlayer.clip = cutscenesVideos[cutSceneNow];
        cutscenesPlayer.Play();
        StartCoroutine("playAudioDelay");
        uiControl.DesabilitarMouse();
    }

    public void EndVideo()
    {
        playingVideo = false;
        cutscenesPlayer.Stop();
        cutsceneAudio.Stop();
        uiControl.HabilitarMouse();
    }

    public IEnumerator playAudioDelay()
    {
        yield return new WaitForSeconds(waitTime);
        cutsceneAudio.clip = cutsceneAudioList[cutSceneNow];
        cutsceneAudio.Play();
    }
}
