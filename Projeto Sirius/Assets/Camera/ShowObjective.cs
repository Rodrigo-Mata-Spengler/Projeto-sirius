using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShowObjective : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cameraChange;
    [SerializeField] private string playerTag;

    
    [SerializeField] private float delay = 0;
    private float tempo = 0;
    private bool usar = false;
    private void Update()
    {
        if (usar && tempo < Time.time)
        {
            cameraChange.Priority = 9;

            DestroyImmediate(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            cameraChange.Priority = 11;
            tempo = delay + Time.time;
            usar = true;
        }
    }
}
