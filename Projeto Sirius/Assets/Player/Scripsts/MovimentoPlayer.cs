using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlayer : MonoBehaviour
{
    private Rigidbody player;
    private float velocidadeAtual;
    private Vector2 playerInput;

    [Header("Velocidade Caminhada")]
    [SerializeField] private float velocidadeNormal = 0;

    [Header("velocidade Corrida")]
    private bool correndo = false;
    [SerializeField] private float velocidadeCorridaNormal = 0;

    [Header("Pulo")]
    [SerializeField] private float puloNormal = 0;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
       Debug.Log("Mover:"+context.ReadValue<Vector2>());
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
        correndo = !correndo;
        
    }

    private void VelocidadeBrain()
    {
        
    }

    private void Update()
    {
        Debug.Log(correndo);
        player.velocity = new Vector3(playerInput.x*velocidadeNormal,0,0);
        //Debug.Log("velocidade:" + player.velocity);
    }
}
