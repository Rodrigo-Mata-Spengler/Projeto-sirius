using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDoor : MonoBehaviour
{
    [Header("Push Configs")]
    [SerializeField] private float PushSpeed = 1f;
    [SerializeField] public bool IsPushDoor;
    public bool touching = false;
    [SerializeField]
    private float RotationAmount = 90f;
    [SerializeField]
    private float ForwardDirection = 0;

    // Start is called before the first frame update
    private Vector3 StartRotation;
    private Vector3 StartPosition;
    private Vector3 Forward;

    private Coroutine AnimationCoroutine;

    // Update is called once per frame
    public void Push(Vector3 UserPosition)
    {
        float dot = Vector3.Dot(Forward, (UserPosition - transform.position).normalized);
        Debug.Log($"Dot: {dot.ToString("N3")}");
        AnimationCoroutine = StartCoroutine(DoPushOpen(dot, PushSpeed));
    }

    private IEnumerator DoPushOpen(float ForwardAmount, float speed)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if (ForwardAmount >= ForwardDirection)
        {
            endRotation = Quaternion.Euler(new Vector3(0, StartRotation.y + RotationAmount, 0));
        }
        else
        {
            endRotation = Quaternion.Euler(new Vector3(0, StartRotation.y - RotationAmount, 0));
        }

      
        float time = 0;
        while (Input.GetAxis("Horizontal") > 0f && time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }
}
