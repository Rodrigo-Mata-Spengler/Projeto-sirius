using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinal : MonoBehaviour
{
    [Header("Menu Morte")]
   [SerializeField] private PauseMenu morte;

    [Header("Destino Boss")] 
    [SerializeField] private Transform pontoFinal;
    [SerializeField] private float velocidade = 0;
    [SerializeField] private float velocidadeNormal = 0;
    [SerializeField] private float tempoLentidao = 0;
    [SerializeField] private float velocidadeLentidao = 0;
    private float fimDaEspera = 0;
    private bool lentidao = false;

    [SerializeField] private float tempoInicio = 0;
    private float tempoInicio_temp = 0;

    [Header("Tags")]
    [SerializeField] private string playerTag;
    [SerializeField] private string lentoTag;

    private void Start()
    {
        velocidade = velocidadeNormal;

        tempoInicio_temp = Time.time + tempoInicio;
    }

    private void Update()
    {
        if (tempoInicio_temp <= Time.time)
        {
            if (lentidao)
            {
                if (fimDaEspera <= Time.time)
                {
                    velocidade = velocidadeNormal;
                    lentidao = false;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, pontoFinal.position, velocidade * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entrou");

        //caso player seja capturado pelo Boss
        if (other.gameObject.CompareTag(playerTag))
        {
            morte.Death(TipoMorte.capturado);
        }

        //caso o player tenha falado com o npc que vai ajudalo
        if (other.gameObject.CompareTag(lentoTag) && lentidao == false)
        {
            fimDaEspera = tempoLentidao + Time.time;
            velocidade = velocidadeLentidao;
            lentidao = true;
        }
    }
}
