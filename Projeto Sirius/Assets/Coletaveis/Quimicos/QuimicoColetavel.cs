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

    private void Update()
    {
        if (button && interacao)
        {
            button = false;

            player.GetComponent<QuimicoPlayer>().ReabastecerQuimico(quantidade);

            Destroy(this.gameObject);
        }
    }

    public void OnColetar(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            button = true;
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
