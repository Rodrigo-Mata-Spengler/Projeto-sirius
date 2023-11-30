using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class FimVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;

    [SerializeField] private string proximaScena;

    private void Update()
    {
        if (!video.isPlaying)
        {
            SceneManager.LoadScene(proximaScena);
        }
    }

}
