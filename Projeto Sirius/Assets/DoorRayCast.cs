using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRayCast : MonoBehaviour
{
    public float rayDistance;
    public LayerMask UseLayer;
    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position,transform.right, out RaycastHit hit, rayDistance, UseLayer) && hit.collider.TryGetComponent<Door>(out Door door))
        {
            if (!door.IsOpen)
            {
                door.Open(transform.position);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + rayDistance, transform.position.y, transform.position.z));
    }
}
