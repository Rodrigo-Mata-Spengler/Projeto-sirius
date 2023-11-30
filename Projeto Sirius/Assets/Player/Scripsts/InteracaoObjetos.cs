using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

enum ButtonStatus {idle , press , released };
public class InteracaoObjetos : MonoBehaviour
{
    [SerializeField]private ButtonStatus button = ButtonStatus.idle;

    [Header("Tag Status")]
    [SerializeField] public string tag;
    [Header("Player")]
    [SerializeField] private QuimicoPlayer qPlayer;
    [SerializeField] private MovimentoPlayer mPlayer;
    [SerializeField] private LedgeDetect ledgePlayer;
    [SerializeField] private PlayerAnim animPlayer;

    [Header("Arrastar Objetos")]
    [SerializeField] private GameObject ancoraPlayer;
    [SerializeField] private string tagArrastarObjeto;
    private bool interacaoArrasta = false;
    private GameObject objeto;

    [Header("Quimico Coletavel")]
    [SerializeField] public string tagQuimicoColetavel;
    [SerializeField] public QuimicoColetavel quimicoColetavel;
    private bool interacaoQuimico = false;
    [SerializeField] private StudioEventEmitter quimicoColetavel_Sound;

    [Header("Escalada")]
    [SerializeField] public string tagSubirParede;
    [SerializeField] public string tagSubirCorda;

    [Header("Se Pendurar")]
    [SerializeField] private string tagPendurar;
    [SerializeField] private GameObject ancoraPendurar;
    private bool interacaoPendurar = false;
    private Transform original_parent;

    [Header("Light Switch")]
    [SerializeField] private string tagLightSwitch;
    [SerializeField] private LuzTrigger luz;
    private bool interacaoLightSwitch = false;

    [Header("Wall")]
    [SerializeField] private string tagBreakWall;
    [SerializeField] private DestructibleWall wall;
    private bool interacaoWall= false;

    [Header("Alavanca")]
    [SerializeField] private string tagAlavanca;
    [SerializeField] private DoorButton door;
    private bool interacaoAlavanca = false;

    [Header("CheckPoint")]
    [SerializeField] private string tagCheckPoint;
    [SerializeField] private CheckPoint checkPoint;
    private bool interacaoCheckPoint = false;

    [Header("Colecionaveis")]
    [SerializeField] private string tagColecionavel;
    [SerializeField] Colecionavel colecionavel;
    private bool interacaoColecionavel = false;
    [SerializeField] private StudioEventEmitter colecionaveis_Sound;

    private void Start()
    {
        qPlayer = GetComponent<QuimicoPlayer>();
        mPlayer = GetComponent<MovimentoPlayer>();
        ledgePlayer = GetComponent<LedgeDetect>();
        original_parent = gameObject.transform.parent;
    }

    private void Update()
    {
        if (interacaoArrasta && button == ButtonStatus.press && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
        {
            Arrasta();
        }
        else if (interacaoPendurar && button == ButtonStatus.press && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
        {
            Pendurar();
        }
        else if (interacaoQuimico && button == ButtonStatus.press)
        {
            interacaoQuimico = false;
            quimicoColetavel.Reabastecer();
            if (!quimicoColetavel_Sound.IsPlaying())
            {
                quimicoColetavel_Sound.Play();
            }
        }
        else if (interacaoLightSwitch && button == ButtonStatus.press)
        {
            luz.LightOn();
        }
        else if (interacaoAlavanca && button == ButtonStatus.press)
        {
            door.OpenDoor(transform);
        }
        else if (interacaoCheckPoint && button == ButtonStatus.press)
        {
            checkPoint.savePlayer(transform.gameObject);
        }else if (interacaoColecionavel && button == ButtonStatus.press)
        {
            Coletar();
        }
        else if (interacaoWall && button == ButtonStatus.press && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
        {
            wall.BreakWall();
            animPlayer.BaterParede();
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
        if (!ledgePlayer.IsClimbing() || !ledgePlayer.IsLedge())
        {
            gameObject.transform.SetParent(ancoraPendurar.transform);
            mPlayer.enabled = false;
        }
    }
    private void SoltarPendurar()
    {
        if (!ledgePlayer.IsClimbing() || !ledgePlayer.IsLedge())
        {
            gameObject.transform.SetParent(original_parent);
            mPlayer.enabled = true;
        }
    }

    //coletar colecionavel
    private void Coletar()
    {
        this.GetComponent<PlayerInventario>().PegarColetavel(colecionavel.colecionavelID);

        if (!colecionaveis_Sound.IsPlaying())
        {
            colecionaveis_Sound.Play();
        }

        interacaoColecionavel = false;

        Destroy(colecionavel.gameObject);

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
        
        }else if (other.gameObject.CompareTag(tagBreakWall))
        {
            interacaoWall = true;
            wall = other.gameObject.GetComponent<DestructibleWall>();
        }
        else if (other.gameObject.CompareTag(tagAlavanca))
        {
            interacaoAlavanca = true;
            door = other.gameObject.GetComponent<DoorButton>();
        }
        else if (other.gameObject.CompareTag(tagCheckPoint))
        {
            interacaoCheckPoint = true;
            checkPoint = other.gameObject.GetComponent<CheckPoint>();
        }
        else if (other.gameObject.CompareTag(tagColecionavel))
        {
            interacaoColecionavel = true;
            colecionavel = other.gameObject.GetComponent<Colecionavel>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        tag = null ;
        Solta();
        if (other.gameObject.CompareTag(tagArrastarObjeto) || interacaoArrasta)
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
        else if (other.gameObject.CompareTag(tagAlavanca))
        {
            interacaoAlavanca = false;
            door = null;
        }
        else if (other.gameObject.CompareTag(tagCheckPoint))
        {
            interacaoCheckPoint = false;
            checkPoint = null;
        }
        else if (other.gameObject.CompareTag(tagColecionavel))
        {
            interacaoColecionavel = false;
            colecionavel = null;
        }
    }
}
