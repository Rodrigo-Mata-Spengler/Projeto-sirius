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

    private void Start()
    {
        qPlayer = GetComponent<QuimicoPlayer>();
        mPlayer = GetComponent<PlayerMovimento>();
    }
    private void Update()
    {
        if (interacaoArrasta && Input.GetButtonDown("Interagir") && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
        {
            Arrasta();
        }else if (interacaoEscalar && Input.GetButtonDown("Interagir") && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
        {
            Escalar();
        }

        if (Input.GetButtonUp("Interagir") || qPlayer.GetQuimicoAtual() < qPlayer.GetAbstinencia())
        {
            Solta();
            SoltarEscalada();
        }
    }

    //para arrastar objetos
    private void Arrasta()
    {
        objeto.transform.SetParent(ancoraPlayer.transform);
    }
    private void Solta()
    {
        if (objeto)
        {
            objeto.transform.SetParent(gameObject.transform.parent);
        }
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
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagArrastarObjeto))
        {
            interacaoArrasta = false;
            objeto = null;
        }
        if (other.gameObject.CompareTag(tagSubirParede))
        {
            interacaoEscalar = false;
        }
    }
}
