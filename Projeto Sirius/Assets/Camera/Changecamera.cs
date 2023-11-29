using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

enum CamMode {enter ,exit }
public class Changecamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cameraChange;
    [SerializeField] private string playerTag;

    [SerializeField] private CamMode mode;
    [SerializeField] private float delay = .2f;
    private float tempo = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (mode == CamMode.enter && tempo<Time.time)
            {
                cameraChange.Priority = 11;

                mode = CamMode.exit;

                tempo = delay + Time.time;

            }else if (mode == CamMode.exit && tempo < Time.time)
            {
                cameraChange.Priority = 9;

                mode = CamMode.enter;

                tempo = delay + Time.time;
            }

            
        }
    }

}
