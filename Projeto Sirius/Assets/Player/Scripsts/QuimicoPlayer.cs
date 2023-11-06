using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

enum Statusquimico {Abstinencia, Normal, Overdose};
public class QuimicoPlayer : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private Statusquimico status = Statusquimico.Normal;
    [HideInInspector] public PauseMenu menuMorte;

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
    private bool aplicar = false;
    private float tempUso = 0;
    [SerializeField] private float delayUso = 0;

    [Header("Modo teste")]
    [SerializeField] private bool desligarCadencia = false;

    private void Start()
    {
        tempCadencia = cadencia + Time.time;
    }

    private void Update()
    {
        if (tempCadencia <= Time.time && !desligarCadencia)
        {
            quimicoatual -= perda;

            tempCadencia = cadencia + Time.time;
        }

        if (quimicoatual <= 0)
        {
            menuMorte.Death();
        }

        if (quimicoatual >= 0)
        {
            menuMorte.Death();
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

        if (aplicar && tempUso <= Time.time)
        {
            if (quimicos > 0)
            {
                quimicoatual += quantidadeReabastecer;
                quimicos -= 1;
                tempUso = Time.time + delayUso;
            }
        }
    }

    public void OnAplicar(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            aplicar = true;
        }
        else if(context.canceled)
        {
            aplicar = false;
        }
    }
    public void ReabastecerQuimico(int a)
    {
        quimicos += a;
    }
    public float GetQuimicoAtual()
    {
        return quimicoatual;
    }
    public void SetQuimicoAtual(float quimico_atual)
    {
        quimicoatual = quimico_atual;
    }
    public float GetAbstinencia()
    {
        return abstinencia;
    }
    public float GetOverdose()
    {
        return overdose;
    }
    public int getQuimico()
    {
        return quimicos;
    }
    public void SetQuimico(int quimico_atual)
    {
        quimicos = quimico_atual;
    }
    public bool IsInOverdose()
    {
        return quimicoatual >= overdose;
    }
    public float StatusTranslator()
    {
        float temp = 0;

        switch (status)
        {
            case Statusquimico.Abstinencia:
                temp = 0;
                break;
            case Statusquimico.Normal:
                temp = 1;
                break;
            case Statusquimico.Overdose:
                temp = 2;
                break;
        }

        return temp;
    }
}
