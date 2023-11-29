using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuimicoColetavel : MonoBehaviour
{
    [SerializeField] private int quantidade;
    private bool interacao = false;
    private bool button = false;
    private GameObject player;

    public void Reabastecer()
    {
        player.GetComponent<QuimicoPlayer>().ReabastecerQuimico(quantidade);

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        player = null;
    }
}
