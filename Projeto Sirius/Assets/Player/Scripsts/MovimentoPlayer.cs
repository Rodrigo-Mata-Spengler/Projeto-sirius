using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlayer : MonoBehaviour
{
    private Rigidbody player;
    private float velocidadeAtual;

    [Header("Velocidade Caminhada")]
    [SerializeField] private float velocidadeNormal;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Mover:"+context.ReadValue<Vector2>());
        velocidadeAtual = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
    }

    public void OnEscalar(InputAction.CallbackContext context)
    {
        Debug.Log("Escalar:"+context.ReadValue<float>());
    }

    public void OnAgacahr(InputAction.CallbackContext context)
    {
        Debug.Log("agachar");
    }

    private void Update()
    {
        player.velocity = new Vector3(velocidadeNormal*velocidadeAtual,0,0);
    }
}
