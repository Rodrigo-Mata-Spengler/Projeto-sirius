using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyStatus { idle, movendo, Atraido, procurando, Achou}
public class EnemyControler : MonoBehaviour
{
    private GameObject player = null;
    private PauseMenu pauseMorte;

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
    [SerializeField] private string playeTag;
    [SerializeField] private string pointTag;

    [Header("Idle")]
    [SerializeField] private float esperaIdle = 0;
    private float proximaEsperaIdle = 0;

    [Header("Tempo de procura")]
    [SerializeField] private float esperaProcura = 0;
    private float proximaEsperaProcura = 0;

    private void Start()
    {
        enemyRigi = GetComponent<Rigidbody>();
        proximaEsperaIdle = esperaIdle + Time.time;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pontoMov,.5f);
    }

    public void EnemyBuilder(AreaEnemy area,float vel,float velInt,float distanciaMax,PauseMenu pausem)
    {
        areaMovimento = area;
        velocidade = vel;
        distanciaMaxima = distanciaMax;
        velocidadeInteresse = velInt;
        pauseMorte = pausem;
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
        pontoMov = new Vector3(pontoDeInteresse.x,transform.position.y, transform.position.z);
        if (status != EnemyStatus.procurando && status != EnemyStatus.procurando && status != EnemyStatus.Achou)
        {
            status = EnemyStatus.Atraido;
        }
    }

    public void FoundPlayer(GameObject player)
    {
        this.player = player;
    }

    private void Idle()
    {
        if (proximaEsperaIdle <= Time.time)
        {
            pontoMov = new Vector3(areaMovimento.RandomPointInSpace().x, transform.position.y, transform.position.z);
            status = EnemyStatus.movendo;
        }
    }

    private void Movendo()
    {
        transform.position = Vector3.MoveTowards(transform.position, pontoMov, velocidade * Time.deltaTime);

        if (transform.position.x == pontoMov.x)
        {
            proximaEsperaIdle = esperaIdle + Time.time;
            status = EnemyStatus.idle;
        }
    }

    private void Atraido()
    {
        transform.position = Vector3.MoveTowards(transform.position, pontoMov, velocidadeInteresse  * Time.deltaTime);

        if (Vector3.Distance(transform.position, pontoMov) <= distanciaMaxima)
        {
            proximaEsperaProcura = esperaProcura + Time.time;
            status = EnemyStatus.procurando;
        }
    }

    private void Procurando()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position + new Vector3(0, 2, 0), (pontoMov - transform.position ), out hit, Mathf.Infinity);
        Debug.DrawRay(transform.position, (pontoMov - transform.position));


        Debug.Log(hit.transform.tag);
        if (proximaEsperaProcura <= Time.time)
        {
            pontoMov = new Vector3(areaMovimento.RandomPointInSpace().x, transform.position.y, transform.position.z);
            status = EnemyStatus.movendo;
        }
        else if (hit.transform.CompareTag(pointTag))
        {

        } 
        else if(hit.transform.CompareTag(playeTag))
        {
            status = EnemyStatus.Achou;
        }
    }

    private void Achou()
    {
        pauseMorte.Death();
    }
}
