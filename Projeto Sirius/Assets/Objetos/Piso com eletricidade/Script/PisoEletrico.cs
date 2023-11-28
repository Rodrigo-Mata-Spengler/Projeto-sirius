using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisoEletrico : MonoBehaviour
{
    [Header("Menu Pause")]
    [SerializeField] private PauseMenu menuMorte;

    [Header("Tag Player")]
    [SerializeField] private string playerTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            menuMorte.Death( TipoMorte.eletrocutado);
        }
    }
}
