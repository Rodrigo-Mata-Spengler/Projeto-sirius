using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoObjetos : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private QuimicoPlayer qPlayer;
    [SerializeField] private PlayerMovimento mPlayer;

    [Header("Arrastar Objetos")]
    [SerializeField] private GameObject ancoraPlayer;
    [SerializeField] private string tagArrastarObjeto;
    private bool interacaoArrasta = false;
    private GameObject objeto;

    [Header("Subir nas Paredes")]
    [SerializeField] private string tagSubirParede;
    private bool interacaoEscalar = false;

    [Header("Se Pendurar")]
    [SerializeField] private string tagPendurar;
    [SerializeField] private GameObject ancoraPendurar;
    private bool interacaoPendurar = false;
    private Transform original_parent;
    private void Start()
    {
        qPlayer = GetComponent<QuimicoPlayer>();
        mPlayer = GetComponent<PlayerMovimento>();
        original_parent = gameObject.transform.parent;
    }
    private void Update()
    {
        if (interacaoArrasta && Input.GetButtonDown("Interagir") && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
        {
            Arrasta();
        }else if (interacaoEscalar && Input.GetButtonDown("Interagir") && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
        {
            Escalar();
        }else if (interacaoPendurar && Input.GetButton("Interagir") && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
        {
            Pendurar();
        }

        if (Input.GetButtonUp("Interagir") || qPlayer.GetQuimicoAtual() < qPlayer.GetAbstinencia())
        {
            Solta();
            SoltarEscalada();
            SoltarPendurar();
        }
    }

    //para arrastar objetos
    private void Arrasta()
    {
        objeto.transform.SetParent(ancoraPlayer.transform);

        mPlayer.arrastando = true;
    }
    private void Solta()
    {
        if (objeto)
        {
            objeto.transform.SetParent(gameObject.transform.parent);
        }
        mPlayer.arrastando = false;
    }

    //para escalar
    private void Escalar()
    {
        mPlayer.movVertical = true;
    }
    private void SoltarEscalada()
    {
        mPlayer.movVertical = false;
    }

    //para pendurar
    private void Pendurar()
    {
        gameObject.transform.SetParent(ancoraPendurar.transform);
        mPlayer.enabled = false;
    }
    private void SoltarPendurar()
    {
        gameObject.transform.SetParent(original_parent);
        mPlayer.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagArrastarObjeto))
        {
            interacaoArrasta = true;
            objeto = other.gameObject;
        }
        else if(other.gameObject.CompareTag(tagSubirParede))
        {
            interacaoEscalar = true;
        }else if (other.gameObject.CompareTag(tagPendurar))
        {
            interacaoPendurar = true;
            ancoraPendurar = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagArrastarObjeto))
        {
            interacaoArrasta = false;
            objeto = null;
            Solta();
        }
        if (other.gameObject.CompareTag(tagSubirParede))
        {
            interacaoEscalar = false;
            SoltarEscalada();
        }
        else if (other.gameObject.CompareTag(tagPendurar))
        {
            interacaoPendurar = false;
            ancoraPendurar = null;
            SoltarPendurar();
        }
    }
}
