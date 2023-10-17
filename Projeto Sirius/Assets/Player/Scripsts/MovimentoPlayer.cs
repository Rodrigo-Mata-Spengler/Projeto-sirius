using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlayer : MonoBehaviour
{
    private Rigidbody player;
    private CharacterController playerControler;
    private float velocidadeAtual;
    private Vector3 playerInput;
    private InteracaoObjetos playerInteracao;
    private Vector3 moveDirection;
    private QuimicoPlayer playerQuimico;
    private LedgeDetect ledge;
    private float lastIpunt = 0;
    [SerializeField] private float forcaAtual = 0;

    [Header("Velocidade Caminhada")]
    [SerializeField] private float velocidadeAbstinencia = 0;
    [SerializeField] private float velocidadeNormal = 0;
    [SerializeField] private float velocidadeOverdose = 0;
    private bool escalando = false;

    [Header("velocidade Corrida")]
    [SerializeField] private float velocidadeCorridaAbstinencia = 0;
    [SerializeField] private float velocidadeCorridaNormal = 0;
    [SerializeField] private float velocidadeCorridaOverdose = 0;
    private bool correndo = false;
    
    [Header("Escalada")]
    [SerializeField] private float velocidadeEscaladaAbstinencia = 0;
    [SerializeField] private float velocidadeEscaladaNormal = 0;
    [SerializeField] private float velocidadeEscaladaOverdose = 0;
    private bool velocidade = false;

    [Header("Pulo")]
    [SerializeField] private float gravidade = 0;
    [SerializeField] private float puloAbstinencia = 0;
    [SerializeField] private float puloNormal = 0;
    [SerializeField] private float puloOverdose = 0;
    private bool pulando = false;
    
    [Header("Agachar")]
    [SerializeField] private float alturaAgachado = 0;
    [SerializeField] private float velocidadeAgachadoNormal = 0;
    private float alturaAtual = 0;
    private bool agachado = false;

    [Header("Arrastar")]
    [SerializeField] private float velocidadeArrastandoNormal = 0;
    [SerializeField] private float velocidadeArrastandoOverdose = 0;
    [SerializeField] private float puloArrastando = 0;
    [HideInInspector]public bool arrastando = false;
    
    private void Start()
    {
        player = GetComponent<Rigidbody>();
        playerControler = GetComponent<CharacterController>();
        playerInteracao = GetComponent<InteracaoObjetos>();
        playerQuimico = GetComponent<QuimicoPlayer>();
        alturaAtual = playerControler.height;
        ledge = transform.GetChild(1).GetComponent<LedgeDetect>();
        playerInput = new Vector3(0, 0, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 temp = context.ReadValue<Vector2>();
        playerInput.x = temp.x;
        playerInput.y = temp.y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 0)
        {
            pulando = false;
        }
        else
        {
            pulando = true;
        }

    }

    public bool OnEscalar()
    {
        if (playerInteracao.tag == playerInteracao.tagSubirParede && ledge.IsClimbing())
        {
            return escalando = true;
        }
        else
        {
            return escalando = false;
        }
    }

    public void OnAgacahr(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 0)
        {
            agachado = false;
        }
        else
        {
            agachado = true;
            Debug.Log("teste!");
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 0)
        {
            correndo = false;
        }else
        {
            correndo = true;
        }
    }

    private float VelocidadeBrain()
    {
        float temp = 0;
        if (agachado)
        {
            temp = velocidadeAgachadoNormal;
        }
        else if (arrastando)
        {
            if (playerQuimico.StatusTranslator() == 0)
            {
                temp = 0;
            }
            else if (playerQuimico.StatusTranslator() == 1)
            {
                temp = velocidadeArrastandoNormal;
            }
            else if (playerQuimico.StatusTranslator() == 2)
            {
                temp = velocidadeArrastandoOverdose;
            }
        }
        else if(escalando)
        {
            if (playerQuimico.StatusTranslator() == 0)
            {
                temp = velocidadeEscaladaAbstinencia;
            }
            else if (playerQuimico.StatusTranslator() == 1)
            {
                temp = velocidadeEscaladaNormal;
            }
            else if (playerQuimico.StatusTranslator() == 2)
            {
                temp = velocidadeCorridaOverdose;
            }
        }
        else 
        {
            if (correndo)
            {
                if (playerQuimico.StatusTranslator() == 0)
                {
                    temp = velocidadeCorridaAbstinencia;
                }
                else if (playerQuimico.StatusTranslator() == 1)
                {
                    temp = velocidadeCorridaNormal;
                }
                else if (playerQuimico.StatusTranslator() == 2)
                {
                    temp = velocidadeCorridaOverdose;
                }
            }
            else
            {
                if (playerQuimico.StatusTranslator() == 0)
                {
                    temp = velocidadeAbstinencia;
                }
                else if (playerQuimico.StatusTranslator() == 1)
                {
                    temp = velocidadeNormal;
                }
                else if(playerQuimico.StatusTranslator() == 2)
                {
                    temp = velocidadeOverdose;
                } 
            }
        }

        return temp;
    }
    private float PuloBrain()
    {
        float temp = 0;
        if (playerQuimico.StatusTranslator() == 0)
        {
            temp = puloAbstinencia;
        }
        else if (playerQuimico.StatusTranslator() == 1)
        {
            temp = puloNormal;
        }
        else if (playerQuimico.StatusTranslator() == 2)
        {
            temp = puloOverdose;
        }

        if (arrastando)
        {
            temp = puloArrastando;
        }

        return temp;
    }
    private void Agachar()
    {
        if (agachado)
        {
            playerControler.height = alturaAgachado;
        }
        else
        {
            playerControler.height = alturaAtual;
        }
    }
    private void Update()
    {
        if (OnEscalar())
        {
            MovimentoVerticalplayer();
        }
        else if (ledge.IsLedge())
        {
            MovimentLedge();
        }
        else
        {
            Agachar();
            MovimentPlayer();
        }
        
    }

    private void MovimentoVerticalplayer()
    {
        moveDirection = new Vector3(playerInput.x, playerInput.y, 0);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= VelocidadeBrain();
        playerControler.Move(moveDirection * Time.deltaTime);
    }
    private void MovimentPlayer()
    {
        
        if (playerControler.isGrounded)
        {
            moveDirection = new Vector3(playerInput.x, 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= VelocidadeBrain();
            if (pulando)
            {
                moveDirection.y = PuloBrain();
            }
        }
        else
        {
            moveDirection.x = playerInput.x;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= VelocidadeBrain();
        }

        moveDirection.y -= gravidade * Time.deltaTime;
        playerControler.Move(moveDirection * Time.deltaTime);

    }

    private void MovimentLedge()
    {

        moveDirection = new Vector3(playerInput.x, 0, 0);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= VelocidadeBrain();
        if (pulando)
        {
            moveDirection.y = PuloBrain();
        }

        playerControler.Move(moveDirection * Time.deltaTime);

    }

    public float LastInput()
    {
        if(playerInput.x != 0)
        {
            lastIpunt = playerInput.x;
        }

        return lastIpunt;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (playerControler.isGrounded)
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb != null && !rb.isKinematic)
            {
                rb.velocity = hit.moveDirection * forcaAtual;
            }
        }
    }
}