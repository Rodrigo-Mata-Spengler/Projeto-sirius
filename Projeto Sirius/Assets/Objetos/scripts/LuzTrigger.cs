using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTrigger : MonoBehaviour
{
    [SerializeField] private  LightOff lightOffScript;
    private bool inside = false;
    private Transform PlayerTransform;
    // Start is called before the first frame update


    private void Update()
    {
        if (inside && Input.GetButton("Interagir"))
        {
            if(!lightOffScript.off)
            {
                lightOffScript.LightsOff();
            }
            else
            {
                lightOffScript.LightOn();
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
        {
            inside = true;
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
