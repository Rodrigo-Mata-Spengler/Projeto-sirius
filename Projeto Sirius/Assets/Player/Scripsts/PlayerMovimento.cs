using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimento : MonoBehaviour
{
    [SerializeField] private float velocidade = 0;
    [SerializeField] private float pulo = 0;
    [SerializeField] private float gravidade = 0;
    private Vector3 moveDirection;

    private Rigidbody rigidbody;
    private CharacterController pController;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        pController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //definir velocidade do Player
        VelocidadePlayer();
        //definir velocidade de pulo do Player
        PuloPlayer();
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
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
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

    }

    //pular
    private void PuloPlayer()
    {

    }

    //agachar
    private void AgacharPlayer()
    {

    }
}
