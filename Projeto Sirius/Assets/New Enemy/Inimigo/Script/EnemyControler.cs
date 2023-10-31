using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyStatus { idle, movendo, Atraido, procurando, Achou}
public class EnemyControler : MonoBehaviour
{
    [Header("Status Enemy")]
    [SerializeField]private EnemyStatus status = EnemyStatus.idle;
    private Rigidbody enemyRigi;
    private CharacterController enemyChara;

    [Header("Enemy field of view")]
    [SerializeField] private Transform fieldOfView;
    [SerializeField] private float distanciaMaxima = 0;

    [Header("Velocidade")]
    [SerializeField] private float velocidade = 0;

    [Header("Ponto de interesse")]
    [SerializeField] private Vector3 pontoMov;
    private AreaEnemy areaMovimento;

    private void Start()
    {
        enemyRigi = GetComponent<Rigidbody>();
        enemyChara = GetComponent<CharacterController>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pontoMov,.5f);
    }

    public void EnemyBuilder(AreaEnemy area,float vel,float distanciaMax)
    {
        areaMovimento = area;
        velocidade = vel;
        distanciaMaxima = distanciaMax;
    }

    private void Update()
    {
        if(status == EnemyStatus.idle)
        {
            pontoMov = areaMovimento.RandomPointInSpace();
            status = EnemyStatus.movendo;
        }
        if (status == EnemyStatus.movendo)
        {
            transform.position = Vector3.MoveTowards(transform.position,pontoMov,velocidade * Time.deltaTime);

            if (transform.position == pontoMov)
            {
                status = EnemyStatus.idle;
            }
        }
        if (status == EnemyStatus.Atraido)
        {
            transform.position = Vector3.MoveTowards(transform.position, pontoMov, velocidade * Time.deltaTime);

            if (Vector3.Distance(transform.position,pontoMov) <= distanciaMaxima)
            {
                pontoMov = transform.position;
                status = EnemyStatus.procurando;
            }
        }
        if (status == EnemyStatus.procurando)
        {

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
    //cria um ponto aleatorio no espaço
    //se move ate ele
    //se ver o player 
}
