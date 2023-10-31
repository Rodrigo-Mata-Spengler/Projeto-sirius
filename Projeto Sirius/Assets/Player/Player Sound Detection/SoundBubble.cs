using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBubble : MonoBehaviour
{
    [SerializeField] private PlayerMoveStatus playerStatus;
    [SerializeField] private StatusMovimento statusMov = StatusMovimento.idle;
    [SerializeField] private SphereCollider colliderSound;
    [SerializeField] public float soundLevel = 0;

    [SerializeField] public float caminhando = 0;
    [SerializeField] public float correndo = 0;
    [SerializeField] public float pulando = 0;
    [SerializeField] public float agachado = 0;
    [SerializeField] public float parado = 0;
    [SerializeField] public float empurrando = 0;
    [SerializeField] public float escalando = 0;

    private void Start()
    {
        playerStatus.GetStatus();
    }

    private void Update()
    {
        TranslateStatus(playerStatus.GetStatus());

        soundLevel = RaioEsfera();

        colliderSound.radius = soundLevel;
    }

    private float RaioEsfera()
    {
        float temp = 0;

        switch (statusMov)
        {
            case StatusMovimento.caminhando:
                temp = caminhando;
                break;
            case StatusMovimento.correndo:
                temp = correndo;
                break;
            case StatusMovimento.pulando:
                temp = pulando;
                break;
            case StatusMovimento.agachando:
                temp = agachado;
                break;
            case StatusMovimento.empurrando:
                temp = empurrando;
                break;
            case StatusMovimento.escalando:
                temp = escalando;
                break;
            default:
                temp = parado;
                break;
        }

        return temp;
    }

    private void TranslateStatus(float data)
    {
        switch (data)
        {
            case 0:
                statusMov = StatusMovimento.idle;
                break;
            case 1:
                statusMov = StatusMovimento.caminhando;
                break;
            case 2:
                statusMov = StatusMovimento.correndo;
                break;
            case 3:
                statusMov = StatusMovimento.pulando;
                break;
            case 4:
                statusMov = StatusMovimento.caindo;
                break;
            case 5:
                statusMov = StatusMovimento.agachando;
                break;
            case 6:
                statusMov = StatusMovimento.empurrando;
                break;
            case 7:
                statusMov = StatusMovimento.escalando;
                break;
            case 8:
                statusMov = StatusMovimento.agarrando;
                break;
            case 9:
                statusMov = StatusMovimento.agachado_idle;
                break;
        }
    }
}
