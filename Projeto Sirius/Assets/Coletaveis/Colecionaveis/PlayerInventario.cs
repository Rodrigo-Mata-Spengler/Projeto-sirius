using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventario : MonoBehaviour
{
    public bool[] colecionaveis;

    private void Awake()
    {
        colecionaveis = new bool[40];

        PlayerData data = SaveSystem.LoadPlayer();

        for (int i = 0; i < colecionaveis.Length; i++)
        {
            colecionaveis[i] = data.colecionaveis[i];
        }
    }

    public void PegarColetavel(int ID)
    {
        colecionaveis[ID] = true;
    }
}
