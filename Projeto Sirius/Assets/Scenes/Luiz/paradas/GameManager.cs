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
    public int pontuação;


    private void Start()
    {
        PassarInformações();
    }


    public void PassarInformações()
    {
        FolhaScript.nome.text = Fila[i].nome.ToString();
        FolhaScript.idade.text = Fila[i].idade.ToString();
        FolhaScript.Descrição.text = Fila[i].descricaoDosProblemas.ToString();
        FolhaScript.Pontuação.text = pontuação.ToString();
        FolhaScript.Cordão.color = Color.white;
    }

    public void ChecarSePulseiraEstaCorreta()
    {
        if(Fila[i].pulsera == Fila[i].PulseraCerta)
        {
            pontuação += 10;

            i++;

        }
        else
        {
            pontuação -= 10;
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
