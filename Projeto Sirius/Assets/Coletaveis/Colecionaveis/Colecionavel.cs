using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Colecionavel : MonoBehaviour
{
    public int colecionavelID;

    [SerializeField] private TextMeshPro texto;
    [SerializeField] private string numero = "num";

    private void Awake()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data.colecionaveis[colecionavelID])
        {
            Destroy(this.gameObject);
        }
        data = null;

        texto.text = numero;
    }
}
