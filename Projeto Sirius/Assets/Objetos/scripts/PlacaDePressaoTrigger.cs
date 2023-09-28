using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDePressaoTrigger : MonoBehaviour
{
    [SerializeField] private PlacaDePressao[] porta;
    [SerializeField] private PlacaDePressao placaDePressao;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Arrastavel"))
        {
            for (int i = 0; i < porta.Length; i++)
            {
                if (!porta[i].IsOpen)
                {
                    porta[i].Open(other.transform.position);
                    placaDePressao.Open(other.transform.position);

                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Arrastavel"))
        {
            for(int i =0; i< porta.Length; i++)
            {

                if (porta[i].IsOpen)
                {
                    placaDePressao.Close();
                    porta[i].Close();
                }
            }

        }
    }
}
