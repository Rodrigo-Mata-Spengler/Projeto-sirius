using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum TipoMorte {Abstinecia ,Overdose ,capturado ,eletrocutado ,generico, idle}
public class PauseMenu : MonoBehaviour
{

    private bool IsPaused = false;

    [SerializeField] private GameObject OpcoesPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject CheatPanel;
    [SerializeField] private GameObject DeathPanel;
    [SerializeField] private GameObject[] customDeath;
    [SerializeField] private TipoMorte morteAtual = TipoMorte.idle;

    [SerializeField] public PlayerAnim anim;

    private bool dead = false;
    private float tempo_Morte = .5f;
    private float tempo = 0;

    private float tempo_pause = .5f;
    private float tempo2 = 0;

    private void Start()
    {
        Resume();

        foreach (var item in customDeath)
        {
            item.SetActive(false);
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed && tempo2<Time.time)
        {
            tempo2 = tempo_pause + Time.time;
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

    private void Update()
    {
        if (dead)
        {
            if (tempo <= Time.time)
            {
                DeathPanel.SetActive(true);

                switch (morteAtual)
                {
                    case TipoMorte.Abstinecia:
                        customDeath[0].SetActive(true);
                        break;
                    case TipoMorte.Overdose:
                        customDeath[1].SetActive(true);
                        break;
                    case TipoMorte.capturado:
                        customDeath[2].SetActive(true);
                        break;
                }
            }
        }

        
    }

    public void Death(TipoMorte morte)
    {
        switch (morte)
        {
            case TipoMorte.Abstinecia:
                anim.Morte();
                tempo = tempo_Morte + Time.time;

                morteAtual = TipoMorte.Abstinecia;
                
                dead = true;
                break;
            case TipoMorte.Overdose:
                anim.Morte();
                tempo = tempo_Morte + Time.time;

                morteAtual = TipoMorte.Overdose;

                dead = true;
                break;
            case TipoMorte.capturado:
                tempo = tempo_Morte + Time.time;

                morteAtual = TipoMorte.capturado;

                dead = true;
                break;
            case TipoMorte.eletrocutado:
                anim.Morte();
                tempo = tempo_Morte + Time.time;

                morteAtual = TipoMorte.capturado;

                dead = true;
                break;
            case TipoMorte.generico:
                Time.timeScale = 0f;
                DeathPanel.SetActive(true);

                morteAtual = TipoMorte.capturado;

                dead = true;
                break;
        }
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

        Debug.Log("time scale:" + Time.timeScale);
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
