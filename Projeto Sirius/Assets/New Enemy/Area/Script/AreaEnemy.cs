using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemy : MonoBehaviour
{
    [Header("Pontos que definem a area:")]
    [SerializeField] private Transform pontoA;
    private Vector3 pontoApos;
    [SerializeField] private Transform pontoB;
    private Vector3 pontoBpos;
    [SerializeField] private float alturaVisualização = 0;

    [Header("Configuração de inimigos na area:")]
    [SerializeField] private GameObject inimigo;
    [SerializeField] private int quantidadeDeInimigos = 0;
    [SerializeField] private Transform pontoSpawn;
    private Vector3 pontoSpawnpos;
    [SerializeField] private GameObject[] inimigosNoMundo;

    private void OnDrawGizmos()
    {
        TradutorPos();

        //gizmos da area
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(pontoApos + new Vector3(0,alturaVisualização,0), new Vector3(pontoApos.x,alturaVisualização + transform.position.y, pontoBpos.z));
        Gizmos.DrawLine(new Vector3(pontoApos.x, alturaVisualização + transform.position.y, pontoBpos.z), pontoBpos + new Vector3(0, alturaVisualização, 0));
        Gizmos.DrawLine(pontoBpos + new Vector3(0, alturaVisualização, 0), new Vector3(pontoBpos.x,alturaVisualização + transform.position.y, pontoApos.z));
        Gizmos.DrawLine( new Vector3(pontoBpos.x,alturaVisualização + transform.position.y, pontoApos.z), pontoApos + new Vector3(0, alturaVisualização, 0));

        //gizmos do ponto de spawn
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pontoSpawnpos + new Vector3(0, alturaVisualização, 0), 1f);
    }

    private void Start()
    {
        VerifyRequiriments();

        CriarInimigos();
    }

    private void Update()
    {
        TradutorPos();
    }

    //Cria um inimigo no mundo
    private void CriarInimigos()
    {
        inimigosNoMundo = new GameObject[2];

        for (int i = 0; i < quantidadeDeInimigos; i++)
        {
            pontoSpawn.position = RandomPointInSpace();
            inimigosNoMundo[i] = Instantiate(inimigo, pontoSpawn.position + new Vector3(0,alturaVisualização,0), pontoSpawn.rotation);
        }
    }


    //gera um ponto aleatorio dentro da area de inimigos
    public Vector3 RandomPointInSpace()
    {
        Vector3 ponto = new Vector3(0,0,0);

        ponto.x = Random.Range(pontoA.position.x,pontoB.position.x);
        ponto.z = Random.Range(pontoA.position.z,pontoB.position.z);

        return ponto;
    }

    //traduz de posição local para posição mundo
    private void TradutorPos()
    {
        pontoApos = transform.TransformDirection(pontoA.position);
        pontoBpos = transform.TransformDirection(pontoB.position);

        pontoSpawnpos = transform.transform.TransformDirection(pontoSpawn.position);
    }

    //testa para ver se tem os intens necessarios para funcionar
    private void VerifyRequiriments()
    {
        if (!pontoA)
        {
            Debug.LogError("Ponto A não encontrado \n Coloque no Inspetor para que o Sytema funcione corretamente!");
        }

        if (!pontoB)
        {
            Debug.LogError("Ponto B não encontrado \n Coloque no Inspetor para que o Sytema funcione corretamente!");
        }

        if (!inimigo)
        {
            Debug.LogError("Prefab do inimigo não encontrado \n Coloque no Inspetor para que o Sytema funcione corretamente!");
        }

        if (quantidadeDeInimigos == 0)
        {
            Debug.LogError("Valor de Inimigos invalido \n Coloque no Inspetor para que o Sytema funcione corretamente!");
        }

        if (!pontoSpawn)
        {
            Debug.LogError("Ponto De Spawn não encontrado \n Coloque no Inspetor para que o Sytema funcione corretamente!");
        }
    }
}
