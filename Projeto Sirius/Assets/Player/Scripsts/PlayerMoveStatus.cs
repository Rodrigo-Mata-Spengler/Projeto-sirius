using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum StatusMovimento { idle, caminhando, correndo, pulando, caindo, agachando, empurrando, escalando, agarrando}
public class PlayerMoveStatus : MonoBehaviour
{
    private CharacterController playerControler;
    private MovimentoPlayer playerMovimento;
    [SerializeField]private LedgeDetect playerLedge;
    public Vector3 velocidade;

    [SerializeField] private StatusMovimento status = StatusMovimento.idle;

    [Header("Pulando")]
    [SerializeField] private float pulandoOffSet = 0;
    private void Awake()
    {
        playerControler = GetComponent<CharacterController>();
        playerMovimento = GetComponent<MovimentoPlayer>();
        playerLedge = GetComponent<LedgeDetect>();
    }

    private void Update()
    {
        velocidade = playerControler.velocity;

        //testa para ver se o player esta no ar
        if (!playerControler.isGrounded)
        {
            if (velocidade.y > pulandoOffSet)
            {
                status = StatusMovimento.pulando;

            }
            else if (velocidade.y < -1 * pulandoOffSet)
            {
                if (!playerMovimento.agachado)
                {
                    status = StatusMovimento.caindo;
                }
            }
        }
        else
        {
            if (playerMovimento.correndo && velocidade.x != 0)
            {
                status = StatusMovimento.correndo;
            }else if (playerMovimento.agachado)
            {
                status = StatusMovimento.agachando;
            }else if (playerMovimento.arrastando)
            {
                status = StatusMovimento.empurrando;
            }else if (playerMovimento.escalando)
            {
                status = StatusMovimento.escalando;
            }else if (playerLedge.IsLedge())
            {
                status = StatusMovimento.agarrando;
            }
            else
            {
                if (velocidade.x != 0)
                {
                    status = StatusMovimento.caminhando;
                }
                else
                {
                    status = StatusMovimento.idle;
                }
            }
        }
    }
}
