using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class FimVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;

    [SerializeField] private string proximaScena;

    private float wait = .5f;
    private float wait_time = 0f;

    private void Start()
    {
        wait_time = wait + Time.time;
    }

    private void Update()
    {
        if (!video.isPlaying && wait_time < Time.time)
        {
            SceneManager.LoadScene(proximaScena);
        }
    }

    public void OnAnyButton()
    {
        SceneManager.LoadScene(proximaScena);
    }
}
