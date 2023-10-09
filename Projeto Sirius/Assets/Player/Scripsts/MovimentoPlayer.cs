using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlayer : MonoBehaviour
{
    private Rigidbody player;
    private CharacterController playerControler;
    private float velocidadeAtual;
    private Vector2 playerInput;

    [Header("Velocidade Caminhada")]
    [SerializeField] private float velocidadeNormal = 0;

    [Header("velocidade Corrida")]
    private bool correndo = false;
    [SerializeField] private float velocidadeCorridaNormal = 0;

    [Header("Pulo")]
    
    [SerializeField] private float puloNormal = 0;

    public int a = 0;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
        playerControler = GetComponent<CharacterController>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
       playerInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("Jump");
    }

    public void OnEscalar(InputAction.CallbackContext context)
    {
        //Debug.Log("Escalar:"+context.ReadValue<float>());
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
        if (correndo)
        {
            return velocidadeCorridaNormal;
        }else
        {
            return velocidadeNormal;
        }

        return 0;
    }

    private void Update()
    {
        
        player.velocity = new Vector3(playerInput.x* VelocidadeBrain(),0,0);
        //Debug.Log("velocidade:" + player.velocity);
    }
}
