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
    private bool correndo = false;
    [SerializeField] private float velocidadeCorridaNormal = 0;

    [Header("Escalada")]
    private bool velocidade = false;
    [SerializeField] private float velocidadeEscaladaNormal = 0;

    [Header("Pulo")]
    private bool pulando = false;
    [SerializeField] private float gravidade = 0;
    [SerializeField] private float puloNormal = 0;



    private void Start()
    {
        player = GetComponent<Rigidbody>();
        playerControler = GetComponent<CharacterController>();
        playerInteracao = GetComponent<InteracaoObjetos>();
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
        //Debug.Log("agachar");
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
        /*if (escalando)
        {
            temp = velocidadeEscaladaNormal;
        }else */
        if (correndo)
        {
            temp = velocidadeCorridaNormal;
        }else
        {
            temp = velocidadeNormal;
        }

        return temp;
    }

    private void Update()
    {
        Debug.Log(playerInput.y);
        MovimentPlayer();
    }

    private void MovimentPlayer()
    {
        
        if (playerControler.isGrounded)
        {
            moveDirection = new Vector3(playerInput.x, 0, 0);
            if (OnEscalar())
            {
                moveDirection.y = playerInput.y;
                Debug.Log(moveDirection.y);
            }
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

        if (!OnEscalar())
        {
            moveDirection.y -= gravidade * Time.deltaTime;
        }
        //Debug.Log(moveDirection);
        playerControler.Move(moveDirection * Time.deltaTime);

    }
}
