using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRayCast : MonoBehaviour
{
    public float rayDistance;
    public LayerMask UseLayer;

    public bool hited = false;
    private PushDoor DoorScript;
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.right, out RaycastHit hit, rayDistance, UseLayer) && hit.collider.TryGetComponent<PushDoor>(out PushDoor door))
        {
            DoorScript = door;

            door.Push(transform.position);
            door.touching = true;
            hited = true;


        }
        else if(hited)
        {
            DoorScript.touching = false;
            hited = false;
        }
 

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + rayDistance, transform.position.y, transform.position.z));
    }
}
