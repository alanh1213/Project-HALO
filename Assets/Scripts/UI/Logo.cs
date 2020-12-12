using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    VideoPlayer video;
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!video.isPlaying)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
}
