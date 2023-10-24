using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum StatusMovimento { idle, caminhando, correndo, pulando, caindo, agachando, empurrando, escalando, agarrando}
public class PlayerMoveStatus : MonoBehaviour
{
    private CharacterController playerControler;
    public Vector3 velocidade;

    [SerializeField] private StatusMovimento status = StatusMovimento.idle;

    [Header("Pulando")]
    [SerializeField] private float pulandoOffSet = 0;
    private void Awake()
    {
        playerControler = GetComponent<CharacterController>();
    }

    private void Update()
    {
        velocidade = playerControler.velocity;

        
        if (!playerControler.isGrounded)
        {
            if (velocidade.y > pulandoOffSet)
            {
                status = StatusMovimento.pulando;

            }
            else if (velocidade.y < -1 * pulandoOffSet)
            {
                status = StatusMovimento.caindo;

            }
        }
        else
        {
            status = StatusMovimento.idle;
        }
    }
}
