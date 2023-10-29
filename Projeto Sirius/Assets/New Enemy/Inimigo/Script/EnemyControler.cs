using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyStatus { idle, movendo, Atraido, Achou}
public class EnemyControler : MonoBehaviour
{
    [Header("Status Enemy")]
    [SerializeField]private EnemyStatus status = EnemyStatus.idle;
    private Rigidbody enemyRigi;
    private CharacterController enemyChara;

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

    public void EnemyBulder(AreaEnemy area,float vel)
    {
        areaMovimento = area;
        velocidade = vel;
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
    }
    //cria um ponto aleatorio no espaço
    //se move ate ele
    //se ver o player 
}
