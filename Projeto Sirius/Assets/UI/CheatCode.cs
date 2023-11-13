using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatCode : MonoBehaviour
{
    [SerializeField]private SaveManeger saveManeger;
    private GameObject player;

    private void Start()
    {
        player = saveManeger.m_player;
    }

    public void GoLevel1()
    {
        SceneManager.LoadScene("Level 1");
    } 
    public void GoLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void GoLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void ErraseSaveData()
    {
        SaveSystem.ErasePlayer();
    }

    public void ParaCadencia()
    {
        player.GetComponent<QuimicoPlayer>().desligarCadencia = !player.GetComponent<QuimicoPlayer>().desligarCadencia;
    }

    public void ReabastecerQuimicos()
    {
        player.GetComponent<QuimicoPlayer>().ReabastecerQuimico(99);
    }
}
