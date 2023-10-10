using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuimicoColetavel : MonoBehaviour
{
    [SerializeField] private GameObject uiFlutuante;
    [SerializeField] private int quantidade;
    private bool interacao = false;
    private bool button = false;
    private GameObject player;
    private void Start()
    {
        uiFlutuante.SetActive(false);
    }

    public void Reabastecer()
    {
        player.GetComponent<QuimicoPlayer>().ReabastecerQuimico(quantidade);

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        uiFlutuante.SetActive(true);

        player = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        uiFlutuante.SetActive(false);

        player = null;
    }
}
