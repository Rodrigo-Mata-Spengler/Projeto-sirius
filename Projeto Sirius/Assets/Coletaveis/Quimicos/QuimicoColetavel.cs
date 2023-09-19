using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuimicoColetavel : MonoBehaviour
{
    [SerializeField] private GameObject uiFlutuante;
    [SerializeField] private int quantidade;
    private bool interacao = false;
    private GameObject player;
    private void Start()
    {
        uiFlutuante.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButton("Interagir") && interacao)
        {
            player.GetComponent<QuimicoPlayer>().ReabastecerQuimico(quantidade);

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        uiFlutuante.SetActive(true);

        interacao = true;

        player = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        uiFlutuante.SetActive(false);

        interacao = false;

        player = null;
    }
}
