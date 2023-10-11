using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetect : MonoBehaviour
{
    private CharacterController playerControler;
    private Transform playerTransform;
    [SerializeField] private float offSet = 0.1f;

    [Header("LInha Cabeça")]
    [SerializeField] private float tamanhoLinha1 = 0;
    private Vector3 line1Start;
    private Vector3 line1End;
    private bool linha1Colisao = false;

    [Header("Linha Corpo")]
    [SerializeField] private float tamanhoLinha2 = 0;
    private Vector3 line2Start;
    private Vector3 line2End;
    private bool linha2Colisao = false;

    private void Start()
    {
        playerControler = transform.parent.gameObject.GetComponent<CharacterController>();
        playerTransform = transform.parent.gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        DesenharLina1();
        DesenharLina2();

        linha1Colisao = Physics.Linecast(line1Start,line1End);
        linha2Colisao = Physics.Linecast(line2Start,line2End);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(line1Start, line1End);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(line2Start, line2End);
    }

    private void DesenharLina1()
    {
        //cria a linha 1
        line1Start = new Vector3(playerControler.radius + offSet + playerTransform.position.x, (playerControler.height / 2) + playerTransform.position.y, playerTransform.position.z);
        line1End = new Vector3(playerControler.radius + tamanhoLinha1 + offSet + playerTransform.position.x, (playerControler.height / 2) + playerTransform.position.y, playerTransform.position.z);
        line1Start = transform.TransformDirection(line1Start);
        line1End = transform.TransformDirection(line1End);
    }
    
    private void DesenharLina2()
    {
        //cria a linha 2
        line2Start = new Vector3(playerControler.radius + offSet + playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
        line2End = new Vector3(playerControler.radius + tamanhoLinha2 + offSet + playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
        line2Start = transform.TransformDirection(line2Start);
        line2End = transform.TransformDirection(line2End);
    }

    public bool getLinha1()
    {
        return linha1Colisao;
    }

    public bool getLinha2()
    {
        return linha2Colisao;
    }
}
