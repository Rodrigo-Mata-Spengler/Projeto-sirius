using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private bool IsPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrResume();

        }
    }

    public void PauseOrResume()
    {
        if (IsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }


    private void Pause()
    {
        Time.timeScale = 0f;
        IsPaused = true;
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        IsPaused = false;
    }
}
