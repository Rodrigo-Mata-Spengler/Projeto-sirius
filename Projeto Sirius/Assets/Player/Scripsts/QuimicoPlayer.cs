using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Statusquimico {Abstinencia, Normal, Overdose};
public class QuimicoPlayer : MonoBehaviour
{
    //niveis do quimico
    [SerializeField] private float quimicoatual = 0;
    [SerializeField] private float quimicoMaximo = 0;
    [SerializeField] private Statusquimico status = Statusquimico.Normal;

    //qunado é considerado cada modo
    [SerializeField] private float abstinencia = 0;
    [SerializeField] private float overdose = 0;

    public float GetQuimicoAtual()
    {
        return quimicoatual;
    }
    public float GetAbstinencia()
    {
        return abstinencia;
    }
    public float GetOverdose()
    {
        return overdose;
    }

}
