using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


enum StatusMovimento { idle, caminhando, correndo, pulando, caindo, agachando , agachado_idle, empurrando, escalando, escalando_idle, agarrando}
public class PlayerMoveStatus : MonoBehaviour
{
    private CharacterController playerControler;
    private MovimentoPlayer playerMovimento;
    [SerializeField] private LedgeDetect playerLedge;
    public Vector3 velocidade;
    [SerializeField] private GameObject soundB;

    [SerializeField] private StatusMovimento status = StatusMovimento.idle;
    private StatusMovimento lastStatus = StatusMovimento.idle;

    private bool wasFalling = false;

    [Header("Pulando")]
    [SerializeField] private float pulandoOffSet = 0;

    [Header("Sons")]
    [SerializeField] private StudioEventEmitter caindo_Sound;
    [SerializeField] private StudioEventEmitter movendo_Sound;

    private void Awake()
    {
        playerControler = GetComponent<CharacterController>();
        playerMovimento = GetComponent<MovimentoPlayer>();
    }

    private void Update()
    {
        velocidade = playerControler.velocity;

        lastStatus = status;
        //testa para ver se o player esta no ar
        if (!playerControler.isGrounded)
        {
            if (playerMovimento.escalando)
            {
                if (velocidade.y != 0)
                {
                    status = StatusMovimento.escalando;
                    soundB.SetActive(false);
                }
                else
                {
                    status = StatusMovimento.escalando_idle;
                    soundB.SetActive(false);
                }
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

                if (!movendo_Sound.IsPlaying())
                {
                    movendo_Sound.Params[0].Value = 1;
                    movendo_Sound.Play();
                }
                

            } else if (playerMovimento.agachado)
            {
                if(velocidade.x != 0)
                {
                    status = StatusMovimento.agachando;
                    soundB.SetActive(true);

                    if (!movendo_Sound.IsPlaying())
                    {
                        movendo_Sound.Params[0].Value = 2;
                        movendo_Sound.Play();
                    }
                }
                else
                {
                    status = StatusMovimento.agachado_idle;
                    soundB.SetActive(true);

                    movendo_Sound.Stop();
                }   
            } else if (playerMovimento.arrastando)
            {
                status = StatusMovimento.empurrando;
                soundB.SetActive(true);

            } else if (playerMovimento.escalando)
            {
                if (velocidade.y != 0)
                {
                    status = StatusMovimento.escalando;
                    soundB.SetActive(false);
                }
                else
                {
                    status = StatusMovimento.escalando_idle;
                    soundB.SetActive(false);
                }

                
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

                    if (!movendo_Sound.IsPlaying())
                    {
                        movendo_Sound.Params[0].Value = 1;
                        movendo_Sound.Play();
                    }
                }
                else
                {
                    status = StatusMovimento.idle;
                    soundB.SetActive(true);
                    movendo_Sound.Stop();
                }
            }
        }

        //som caindo
        if (lastStatus == StatusMovimento.caindo && lastStatus != status)
        {
            if (wasFalling == true && !caindo_Sound.IsPlaying())
            {
                wasFalling = false;
                caindo_Sound.Play();
            }
        }
        
        if(lastStatus != StatusMovimento.caindo)
        {
            wasFalling = true;
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
            case StatusMovimento.escalando_idle:
                temp = 10;
                break;
        }

        return temp;
    }

}
