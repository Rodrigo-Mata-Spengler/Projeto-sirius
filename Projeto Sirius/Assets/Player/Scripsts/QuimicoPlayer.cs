using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private bool aplicar = false;
    private float tempUso = 0;
    [SerializeField] private float delayUso = 0;

    [Header("Modo teste")]
    [SerializeField] private bool desligarCadencia = false;

    private void Start()
    {
        quimicoatual = 50f;
        tempCadencia = cadencia + Time.time;
    }

    private void Update()
    {
        if (tempCadencia <= Time.time && !desligarCadencia)
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

        if (aplicar && tempUso <= Time.time)
        {
            Debug.Log("usou");
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
        if (context.ReadValue<float>() == 0)
        {
            aplicar = false;
        }
        else
        {
            aplicar = true;
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
    public bool IsInOverdose()
    {
        return quimicoatual >= overdose;
    }

    public float StatusTranslator()
    {
        switch (status)
        {
            case Statusquimico.Abstinencia:
                return 0;
                break;
            case Statusquimico.Normal:
                return 1;
                break;
            case Statusquimico.Overdose:
                return 2;
                break;
            default:
                return 0;
                break;
        }
    }
}
