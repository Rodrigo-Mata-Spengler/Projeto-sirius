using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{

    [SerializeField] private Door Door;
    private bool inside = false;
    private Transform PlayerTransform;
    // Start is called before the first frame update


    private void Update()
    {
        if (inside && Input.GetButton("Interagir"))
        {
            if (!Door.IsOpen)
            {
                Door.Open(PlayerTransform.transform.position);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
        {

            inside = true;
            Debug.Log("Aqui");
            PlayerTransform = other.transform;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
        {
            inside = false;
        }
    }
}
