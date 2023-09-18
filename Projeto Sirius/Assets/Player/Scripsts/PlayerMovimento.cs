using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimento : MonoBehaviour
{
    [Header("Velocidades Atuais")]
    [SerializeField] private float velocidade = 0;
    [SerializeField] private float pulo = 0;
    [SerializeField] private float gravidade = 0;

    [Header("Informações do Player")]
    [SerializeField] private float altura = 0;
    [Header("Abstinencia:")]
    [SerializeField] private float velocidadeAbstinencia = 0;
    [SerializeField] private float velocidadeAbstinenciaCorrendo = 0;
    [SerializeField] private float PuloAbstinencia = 0;
    [Header("Nomrmal:")]
    [SerializeField] private float velocidadeNormal = 0;
    [SerializeField] private float velocidadeNormalCorrendo = 0;
    [SerializeField] private float PuloNormal = 0;
    [Header("Overdose:")]
    [SerializeField] private float velocidadeOverdose = 0;
    [SerializeField] private float velocidadeOverdoseCorrendo = 0;
    [SerializeField] private float PuloOverdose = 0;
    [Header("Agachado:")]
    [SerializeField] private float velocidadeAgachado = 0;
    [SerializeField] private float alturaAgachado = 0;
    private Vector3 moveDirection;

    private Rigidbody rigidbody;
    private CharacterController pController;
    private QuimicoPlayer qPlayer;

    [Header("Temporario")]
    public GameObject sprite;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        pController = GetComponent<CharacterController>();
        qPlayer = GetComponent<QuimicoPlayer>();
    }

    private void Update()
    {
        //definir velocidade do Player
        VelocidadePlayer();
        //agachar
        AgacharPlayer();
        //andar no eixo x e pular
        MovimentPlayer();

    }

    //andar no eixo x e pular
    private void MovimentPlayer()
    {
        if (pController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= velocidade;
            if (Input.GetButton("Jump"))
                moveDirection.y = pulo;
        }
        moveDirection.y -= gravidade * Time.deltaTime;
        pController.Move(moveDirection * Time.deltaTime);
    }

    //correr
    private void VelocidadePlayer()
    {
        if (Input.GetButton("Agachar"))
        {
            pController.height = alturaAgachado;
            velocidade = velocidadeAgachado;
            pulo = 0;
        }
        else
        {
            pController.height = altura;
        }

        if (qPlayer.GetQuimicoAtual() <= qPlayer.GetAbstinencia())
        {
            if (Input.GetButton("Run"))
            {
                velocidade = velocidadeAbstinenciaCorrendo;
            }
            else
            {
                velocidade = velocidadeAbstinencia;
            }

            pulo = PuloAbstinencia;
        }
        else if (qPlayer.GetQuimicoAtual() >= qPlayer.GetOverdose())
        {
            if (Input.GetButton("Run"))
            {
                velocidade = velocidadeOverdoseCorrendo;
            }
            else
            {
                velocidade = velocidadeOverdose;
            }
            pulo = PuloOverdose;
        }
        else if(!Input.GetButton("Agachar"))
        {
            if (Input.GetButton("Run"))
            {
                velocidade = velocidadeNormalCorrendo;
            }
            else
            {
                velocidade = velocidadeNormal;
            }
            pulo = PuloNormal;
        }

        
    }

    //agachar
    private void AgacharPlayer()
    {

    }
}
