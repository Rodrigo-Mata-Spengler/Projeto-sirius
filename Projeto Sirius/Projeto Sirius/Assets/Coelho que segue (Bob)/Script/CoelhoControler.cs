using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CoelhoControler : MonoBehaviour
{
    private NavMeshAgent agente;

    private NavMeshPath path;

    [SerializeField] private GameObject player;

    private bool podeIr = true;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Comando Coelho"))
        {
            podeIr = !podeIr;
        }

        if (podeIr)
        {
            agente.SetDestination(player.transform.position);
        }
        else
        {
            agente.ResetPath();
        }
    }
}
