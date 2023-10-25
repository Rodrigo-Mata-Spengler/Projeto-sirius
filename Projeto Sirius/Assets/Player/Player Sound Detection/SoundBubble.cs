using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBubble : MonoBehaviour
{
    [SerializeField] private float raio;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, raio);
    }

    private void Update()
    {
        Physics.OverlapSphere(transform.position,raio);
    }
}
