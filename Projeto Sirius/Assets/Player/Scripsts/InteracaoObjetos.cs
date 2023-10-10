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

    [Header("Quimico Coletavel")]
    [SerializeField] public string tagQuimicoColetavel;
    [SerializeField] public QuimicoColetavel quimicoColetavel;
    private bool interacaoQuimico = false;

    [Header("Escalada")]
    [SerializeField] public string tagSubirParede;

    [Header("Se Pendurar")]
    [SerializeField] private string tagPendurar;
    [SerializeField] private GameObject ancoraPendurar;
    private bool interacaoPendurar = false;
    private Transform original_parent;

    [Header("Light Switch")]
    [SerializeField] private string tagLightSwitch;
    [SerializeField] private LuzTrigger luz;
    private bool interacaoLightSwitch = false;

    [Header("Alavanca")]
    [SerializeField] private string tagAlavanca;
    [SerializeField] private DoorButton door;
    private bool interacaoAlavanca = false;

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
        }else if (interacaoQuimico && button == ButtonStatus.press)
        {
            interacaoQuimico = false;
            quimicoColetavel.Reabastecer();
        }else if (interacaoLightSwitch && button == ButtonStatus.press)
        {
            luz.LightOn();
        }
        else if (interacaoAlavanca && button == ButtonStatus.press)
        {
            door.OpenDoor(transform);
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
        }else if (other.gameObject.CompareTag(tagQuimicoColetavel))
        {
            interacaoQuimico = true;
            quimicoColetavel =  other.gameObject.GetComponent<QuimicoColetavel>();
        }else if (other.gameObject.CompareTag(tagLightSwitch))
        {
            interacaoLightSwitch = true;
            luz = other.gameObject.GetComponent<LuzTrigger>();
        }
        else if (other.gameObject.CompareTag(tagAlavanca))
        {
            interacaoAlavanca = true;
            door = other.gameObject.GetComponent<DoorButton>();
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
        else if (other.gameObject.CompareTag(tagQuimicoColetavel))
        {
            interacaoQuimico = false;
            quimicoColetavel = null;
        }else if (other.gameObject.CompareTag(tagLightSwitch))
        {
            interacaoLightSwitch = false;
            luz = null;
        }
        if (other.gameObject.CompareTag(tagAlavanca))
        {
            interacaoAlavanca = false;
            door = null;
        }
    }
}
