using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    //scena a onde o player esta
    public string scena_Atual;

    //localiza��o Atual
    public float[] loc_Atual = new float[2];

    //quimico
    public float quantidade_Aplicada = 0;
    public int quantidade_Guardada = 0;

    //colecionaveis
    public bool[] colecionaveis = new bool[40];
    public PlayerData(GameObject player)
    {
        //scena atual
        scena_Atual = SceneManager.GetActiveScene().name;

        //localiza��o do player
        loc_Atual[0] = player.transform.position.x;
        loc_Atual[1] = player.transform.position.y;

        //Quimico do player
        quantidade_Aplicada = player.GetComponent<QuimicoPlayer>().GetQuimicoAtual();
        quantidade_Guardada = player.GetComponent<QuimicoPlayer>().getQuimico();

        //Coletaveis
        bool[] temp = player.GetComponent<PlayerInventario>().colecionaveis;
        for (int i = 0; i < colecionaveis.Length; i++)
        {
            colecionaveis[i] = temp[i];
        }
    }

}