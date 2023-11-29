using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventario : MonoBehaviour
{
    public bool[] colecionaveis;

    private void Awake()
    {
        colecionaveis = new bool[5];

        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            for (int i = 0; i < colecionaveis.Length; i++)
            {
                colecionaveis[i] = data.colecionaveis[i];
            }
        }
        
    }

    public void PegarColetavel(int ID)
    {
        colecionaveis[ID] = true;
    }
}
