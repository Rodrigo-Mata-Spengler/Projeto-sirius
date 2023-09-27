using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool IsPaused = false;

    [SerializeField] private GameObject OpcoesPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject DeathPanel;

    private bool dead = false;

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

    public void Death()
    {
        Time.timeScale = 0f;
        DeathPanel.SetActive(true);
        dead = true;
    }
    public void Reborn()
    {
        Time.timeScale = 1f;
        DeathPanel.SetActive(false);
        SceneManager.LoadScene(1);
        dead = false;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        IsPaused = true;
        PausePanel.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        PausePanel.SetActive(false);
    }

    public void Opcoes()
    {
        PausePanel.SetActive(false);
        OpcoesPanel.SetActive(true);

    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
