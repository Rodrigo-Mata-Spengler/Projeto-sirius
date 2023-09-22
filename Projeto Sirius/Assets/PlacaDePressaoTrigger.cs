using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDePressaoTrigger : MonoBehaviour
{
    [SerializeField] private PlacaDePressao porta;
    [SerializeField] private PlacaDePressao placaDePressao;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!porta.IsOpen)
            {
                porta.Open(other.transform.position);
                placaDePressao.Open(other.transform.position);
               
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (porta.IsOpen)
            {
                placaDePressao.Close();
                porta.Close();
            }
        }
    }
}
