using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum StatusMovimento { idle, caminhando, correndo, pulando, caindo, agachando , agachado_idle, empurrando, escalando, agarrando}
public class PlayerMoveStatus : MonoBehaviour
{
    private CharacterController playerControler;
    private MovimentoPlayer playerMovimento;
    [SerializeField] private LedgeDetect playerLedge;
    public Vector3 velocidade;
    [SerializeField] private GameObject soundB;

    [SerializeField] private StatusMovimento status = StatusMovimento.idle;

    [Header("Pulando")]
    [SerializeField] private float pulandoOffSet = 0;
    private void Awake()
    {
        playerControler = GetComponent<CharacterController>();
        playerMovimento = GetComponent<MovimentoPlayer>();
    }

    private void Update()
    {
        velocidade = playerControler.velocity;

        //testa para ver se o player esta no ar
        if (!playerControler.isGrounded)
        {
            if (playerMovimento.escalando)
            {
                status = StatusMovimento.escalando;
                soundB.SetActive(false);
            }
            else if(velocidade.y > pulandoOffSet)
            {
                status = StatusMovimento.pulando;
                soundB.SetActive(true);

            }
            else if (velocidade.y < -1 * pulandoOffSet)
            {
                if (!playerMovimento.agachado)
                {
                    status = StatusMovimento.caindo;
                    soundB.SetActive(true);
                }
            }
        }
        else
        {
            if (playerMovimento.correndo && velocidade.x != 0)
            {
                status = StatusMovimento.correndo;
                soundB.SetActive(true);
            } else if (playerMovimento.agachado)
            {
                if(velocidade.x != 0)
                {
                    status = StatusMovimento.agachando;
                    soundB.SetActive(true);
                }
                else
                {
                    status = StatusMovimento.agachado_idle;
                    soundB.SetActive(true);
                }   
            } else if (playerMovimento.arrastando)
            {
                status = StatusMovimento.empurrando;
                soundB.SetActive(true);

            } else if (playerMovimento.escalando)
            {
                status = StatusMovimento.escalando;
                soundB.SetActive(false);
            } else if (playerLedge.IsLedge())
            {
                status = StatusMovimento.agarrando;
                soundB.SetActive(true);
            }
            else
            {
                if (velocidade.x != 0)
                {
                    status = StatusMovimento.caminhando;
                    soundB.SetActive(true);
                }
                else
                {
                    status = StatusMovimento.idle;
                    soundB.SetActive(true);
                }
            }
        }
    }

    public float GetStatus()
    {
        float temp = 0;

        switch (status)
        {
            case StatusMovimento.idle:
                temp = 0;
                break;
            case StatusMovimento.caminhando:
                temp = 1;
                break;
            case StatusMovimento.correndo:
                temp = 2;
                break;
            case StatusMovimento.pulando:
                temp = 3;
                break;
            case StatusMovimento.caindo:
                temp = 4;
                break;
            case StatusMovimento.agachando:
                temp = 5;
                break;
            case StatusMovimento.empurrando:
                temp = 6;
                break;
            case StatusMovimento.escalando:
                temp = 7;
                break;
            case StatusMovimento.agarrando:
                temp = 8;
                break;
            case StatusMovimento.agachado_idle:
                temp = 9;
                break;
        }

        return temp;
    }

}
