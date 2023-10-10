using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

enum ButtonStatus {idle , press , released };
public class InteracaoObjetos : MonoBehaviour
{
    [SerializeField]private ButtonStatus button = ButtonStatus.idle;

    [Header("Tag Status")]
    [SerializeField] public string tag;
    [Header("Player")]
    [SerializeField] private QuimicoPlayer qPlayer;
    [SerializeField] private MovimentoPlayer mPlayer;

    [Header("Arrastar Objetos")]
    [SerializeField] private GameObject ancoraPlayer;
    [SerializeField] private string tagArrastarObjeto;
    private bool interacaoArrasta = false;
    private GameObject objeto;

    [Header("Subir nas Paredes")]
    [SerializeField] public string tagSubirParede;
    private bool interacaoEscalar = false;

    [Header("Se Pendurar")]
    [SerializeField] private string tagPendurar;
    [SerializeField] private GameObject ancoraPendurar;
    private bool interacaoPendurar = false;
    private Transform original_parent;
    private void Start()
    {
        qPlayer = GetComponent<QuimicoPlayer>();
        mPlayer = GetComponent<MovimentoPlayer>();
        original_parent = gameObject.transform.parent;
    }
    private void Update()
    {
        if (interacaoArrasta && button == ButtonStatus.press && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
        {
            Arrasta();
        }else if (interacaoPendurar && button == ButtonStatus.press && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
        {
            Pendurar();
        }

        if (button == ButtonStatus.released || qPlayer.GetQuimicoAtual() < qPlayer.GetAbstinencia())
        {
            button = ButtonStatus.idle;
            Solta();
            SoltarPendurar();
            
        }
    }

    public  void OnInteracao(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            button = ButtonStatus.press;
        }else if (context.canceled)
        {
            button = ButtonStatus.released;
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
        tag = other.gameObject.tag;
        if (other.gameObject.CompareTag(tagArrastarObjeto))
        {
            interacaoArrasta = true;
            objeto = other.gameObject;
        }
        else  if (other.gameObject.CompareTag(tagPendurar))
        {
            interacaoPendurar = true;
            ancoraPendurar = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        tag = null ;
        if (other.gameObject.CompareTag(tagArrastarObjeto))
        {
            interacaoArrasta = false;
            objeto = null;
            Solta();
        }
        if (other.gameObject.CompareTag(tagPendurar))
        {
            interacaoPendurar = false;
            ancoraPendurar = null;
            SoltarPendurar();
        }
    }
}
