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

    [Header("Velocidade Caminhada")]
    [SerializeField] private float velocidadeNormal = 0;
    private bool escalando = false;

    [Header("velocidade Corrida")]
    [SerializeField] private float velocidadeCorridaNormal = 0;
    private bool correndo = false;
    
    [Header("Escalada")]
    [SerializeField] private float velocidadeEscaladaNormal = 0;
    private bool velocidade = false;

    [Header("Pulo")]
    [SerializeField] private float gravidade = 0;
    [SerializeField] private float puloNormal = 0;
    private bool pulando = false;
    
    [Header("Agachar")]
    [SerializeField] private float alturaAgachado = 0;
    [SerializeField] private float velocidadeAgachadoNormal = 0;
    private float alturaAtual = 0;
    private bool agachado = false;
    
    private void Start()
    {
        player = GetComponent<Rigidbody>();
        playerControler = GetComponent<CharacterController>();
        playerInteracao = GetComponent<InteracaoObjetos>();
        alturaAtual = playerControler.height;
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
        if (playerInteracao.tag == playerInteracao.tagSubirParede)
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
        }else if (escalando)
        {
            temp = velocidadeEscaladaNormal;
        }else if (correndo)
        {
            temp = velocidadeCorridaNormal;
        }else
        {
            temp = velocidadeNormal;
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
                moveDirection.y = puloNormal;
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
}
