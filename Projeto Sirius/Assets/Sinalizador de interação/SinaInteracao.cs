using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinaInteracao : MonoBehaviour
{
    [SerializeField] private GameObject sinal;
    [SerializeField] private string playerTag;

    private void Start()
    {
        sinal.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            sinal.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            sinal.SetActive(false);
        }
    }
}
