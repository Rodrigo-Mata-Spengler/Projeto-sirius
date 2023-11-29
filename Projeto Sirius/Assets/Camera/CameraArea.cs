using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArea : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cameraChange;
    [SerializeField] private string playerTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            cameraChange.Priority = 11;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            cameraChange.Priority = 9;
        }
    }
}
