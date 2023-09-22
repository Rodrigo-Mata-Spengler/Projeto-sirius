using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Folha FolhaScript;
    public People[] Fila;
    private int i = 0;
    public bool DoOnce = false;
    public int pontua��o;


    private void Start()
    {
        PassarInforma��es();
    }


    public void PassarInforma��es()
    {
        FolhaScript.nome.text = Fila[i].nome.ToString();
        FolhaScript.idade.text = Fila[i].idade.ToString();
        FolhaScript.Descri��o.text = Fila[i].descricaoDosProblemas.ToString();
        FolhaScript.Pontua��o.text = pontua��o.ToString();
        FolhaScript.Cord�o.color = Color.white;
    }

    public void ChecarSePulseiraEstaCorreta()
    {
        if(Fila[i].pulsera == Fila[i].PulseraCerta)
        {
            pontua��o += 10;

            i++;

        }
        else
        {
            pontua��o -= 10;
            i++;

        }
    }

    public void ChangeColorRed()
    {
        Fila[i].pulsera= Pulsera.Vermelho;
        ChecarSePulseiraEstaCorreta();
    }
    public void ChangeColorYellow()
    {
        Fila[i].pulsera = Pulsera.Amarelo;
        ChecarSePulseiraEstaCorreta();
    }
    public void ChangeColorGreem()
    {
        Fila[i].pulsera = Pulsera.Verde;
        ChecarSePulseiraEstaCorreta();
    }
    public void ChangeColorBlue()
    {
        Fila[i].pulsera = Pulsera.Azul;
        ChecarSePulseiraEstaCorreta();
    }
}
