using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoObjetos : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private QuimicoPlayer qPlayer;

    [Header("Arrastar Objetos")]
    [SerializeField] private GameObject ancoraPlayer;
    [SerializeField] private string tagArrastarObjeto;
    private bool interacaoArrasta = false;
    private GameObject objeto;


    private void Start()
    {
        qPlayer = GetComponent<QuimicoPlayer>();
    }
    private void Update()
    {
        if (interacaoArrasta && Input.GetButtonDown("Interagir") && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
        {
            Arrasta();
        }

        if (Input.GetButtonUp("Interagir") || qPlayer.GetQuimicoAtual() < qPlayer.GetAbstinencia())
        {
            Solta();
        }
    }

    private void Arrasta()
    {
        objeto.transform.SetParent(ancoraPlayer.transform);
    }
    private void Solta()
    {
        objeto.transform.SetParent(gameObject.transform.parent);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagArrastarObjeto))
        {
            interacaoArrasta = true;
            objeto = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagArrastarObjeto))
        {
            interacaoArrasta = false;
            objeto = null;
        }
    }
}
