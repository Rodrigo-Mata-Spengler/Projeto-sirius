using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyStatus { idle, movendo, Atraido, procurando, Achou}
public class EnemyControler : MonoBehaviour
{
    [Header("Status Enemy")]
    [SerializeField]private EnemyStatus status = EnemyStatus.idle;
    private Rigidbody enemyRigi;

    [Header("Enemy field of view")]
    [SerializeField] private Transform fieldOfView;
    [SerializeField] private float distanciaMaxima = 0;

    [Header("Velocidade")]
    [SerializeField] private float velocidade = 0;
    [SerializeField] private float velocidadeInteresse = 0;

    [Header("Ponto de interesse")]
    [SerializeField] private Vector3 pontoMov;
    private AreaEnemy areaMovimento;

    [Header("Idle")]
    [SerializeField] private float esperaIdle = 0;
    private float proximaEsperaIdle = 0;

    private void Start()
    {
        enemyRigi = GetComponent<Rigidbody>();;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pontoMov,.5f);
    }

    public void EnemyBuilder(AreaEnemy area,float vel,float velInt,float distanciaMax)
    {
        areaMovimento = area;
        velocidade = vel;
        distanciaMaxima = distanciaMax;
        velocidadeInteresse = velInt;
    }

    private void Update()
    {
        switch (status)
        {
            case EnemyStatus.idle:
                Idle();
                break;
            case EnemyStatus.movendo:
                Movendo();
                break;
            case EnemyStatus.Atraido:
                Atraido();
                break;
            case EnemyStatus.procurando:
                Procurando();
                break;
            case EnemyStatus.Achou:
                Achou();
                break;
        }

    }

    public void NewPointOfInterest(Vector3 pontoDeInteresse)
    {
        if (status != EnemyStatus.Atraido || status != EnemyStatus.procurando)
        {
            pontoMov = pontoDeInteresse;
            status = EnemyStatus.Atraido;
        }
    }

    private void Idle()
    {
        if (proximaEsperaIdle <= Time.time)
        {
            pontoMov = areaMovimento.RandomPointInSpace();
            status = EnemyStatus.movendo;
        }
    }

    private void Movendo()
    {
        transform.position = Vector3.MoveTowards(transform.position, pontoMov, velocidade * Time.deltaTime);

        if (transform.position == pontoMov)
        {
            proximaEsperaIdle = esperaIdle + Time.time;
            status = EnemyStatus.idle;
        }
    }

    private void Atraido()
    {
        transform.position = Vector3.MoveTowards(transform.position, pontoMov, velocidadeInteresse  * Time.deltaTime);

        Debug.Log(Vector3.Distance(transform.position, pontoMov));
        if (Vector3.Distance(transform.position, pontoMov) <= distanciaMaxima)
        {
            status = EnemyStatus.procurando;
        }
    }

    private void Procurando()
    {

    }

    private void Achou()
    {

    }
}
