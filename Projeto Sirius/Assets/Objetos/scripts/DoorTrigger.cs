using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    private Door Door;
    [SerializeField]
    private Door Door2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
        {
            if (!Door.IsOpen)
            {
                Door.Open(other.transform.position);
                Door2.Open(other.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
        {
            if (Door.IsOpen)
            {
                Door.Close();
                Door2.Close();

            }
        }
    }
}
