using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool IsPaused = false;

    [SerializeField] private GameObject OpcoesPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject CheatPanel;
    [SerializeField] private GameObject DeathPanel;

    private bool dead = false;

    private void Start()
    {
        Resume();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
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
        PlayerData data = SaveSystem.LoadPlayer();
        SceneManager.LoadScene(data.scena_Atual);

        Time.timeScale = 1f;
        DeathPanel.SetActive(false);
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
        CheatPanel.SetActive(false);
        OpcoesPanel.SetActive(true);

    }
    public void BackToPausePanel()
    {
        OpcoesPanel.SetActive(false);
        CheatPanel.SetActive(false);
        PausePanel.SetActive(true);
       
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void CheatCode()
    {
        OpcoesPanel.SetActive(false);
        CheatPanel.SetActive(true);
        PausePanel.SetActive(false);
    }

}
