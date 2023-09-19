using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Statusquimico {Abstinencia, Normal, Overdose};
public class QuimicoPlayer : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private Statusquimico status = Statusquimico.Normal;

    [Header("Niveis do quimico")]
    [SerializeField] private float quimicoatual = 0;
    [SerializeField] private float quimicoMaximo = 0;
    

    [Header("Cadencia do quimico")]
    [SerializeField] private float cadencia = 0;
    [SerializeField] private float perda = 0;
    private float tempCadencia = 0;

    [Header("Niveis de estado")]
    [SerializeField] private float abstinencia = 0;
    [SerializeField] private float overdose = 0;

    [Header("Quimicos guardados")]
    [SerializeField] private int quimicos = 0;
    [SerializeField] private float quantidadeReabastecer = 0;

    private void Start()
    {
        quimicoatual = 50f;
        tempCadencia = cadencia + Time.time;
    }

    private void Update()
    {
        if (tempCadencia <= Time.time)
        {
            quimicoatual -= perda;

            tempCadencia = cadencia + Time.time;
        }

        if (quimicoatual <= abstinencia)
        {
            status = Statusquimico.Abstinencia;
        }else if (quimicoatual >= overdose)
        {
            status = Statusquimico.Overdose;
        }
        else
        {
            status = Statusquimico.Normal;
        }

        if (Input.GetButtonDown("Reabastecer"))
        {
            if(quimicos > 0)
            {
                quimicoatual += quantidadeReabastecer;
                quimicos -= 1;
            }
        }
    }
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
