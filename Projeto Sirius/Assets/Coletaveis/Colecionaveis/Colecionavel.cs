using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colecionavel : MonoBehaviour
{
    public int colecionavelID;

    private void Awake()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data.colecionaveis[colecionavelID])
        {
            Destroy(this);
        }
        data = null;
    }
}
