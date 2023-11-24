using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlacaDePressao : MonoBehaviour
{
    public bool IsOpen = false;
    

    [SerializeField]
    private float Speed = 1f;
    [Header("Rotation Configs")]
    [SerializeField]
    private float RotationAmount = 90f;
    [SerializeField]
    private float ForwardDirection = 0;

    [Header("Sliding Configs")]

    [SerializeField] private bool SlidingDoor;
    [SerializeField]
    private Vector3 SlideDirection = Vector3.back;
    [SerializeField]
    private float SlideAmount = 1.9f;

    private Vector3 StartRotation;
    private Vector3 StartPosition;
    private Vector3 Forward;

    private Coroutine AnimationCoroutine;

    [Header("Sons")]
    [SerializeField] private StudioEventEmitter alcapao_Sound;

    private void Awake()
    {
        StartRotation = transform.rotation.eulerAngles;
        // Since "Forward" actually is pointing into the door frame, choose a direction to think about as "forward" 
        Forward = transform.right;
        StartPosition = transform.position;
    }


    public void Open(Vector3 UserPosition)
    {
        if (!IsOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            if (SlidingDoor)
            {
                AnimationCoroutine = StartCoroutine(DoSlidingOpen());
                
            }
            else
            {
                float dot = Vector3.Dot(Forward,transform.position.normalized);
                Debug.Log($"Dot: {dot.ToString("N3")}");
                AnimationCoroutine = StartCoroutine(DoRotationOpen(dot, Speed));
            }

        }
    }

    public void Close()
    {
        if (IsOpen)
        {

            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            if (SlidingDoor)
            {
           
                AnimationCoroutine = StartCoroutine(DoSlidingClose());
            }
            else
            {
                AnimationCoroutine = StartCoroutine(DoRotationClose());
            }
        }
    }
    private IEnumerator DoRotationOpen(float ForwardAmount, float speed)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if (ForwardAmount >= ForwardDirection)
        {
            endRotation = Quaternion.Euler(new Vector3( StartRotation.x + RotationAmount, StartRotation.y , StartRotation.z));
        }
        else
        {
            endRotation = Quaternion.Euler(new Vector3( StartRotation.x - RotationAmount, StartRotation.y, StartRotation.z));
        }

        IsOpen = true;

        if (!alcapao_Sound.IsPlaying())
        {
            alcapao_Sound.Play();
        }

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }


    private IEnumerator DoSlidingOpen()
    {
        Vector3 endPosition = StartPosition + SlideAmount * SlideDirection;
        Vector3 startPosition = transform.position;

        float time = 0;
        IsOpen = true;
        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }

    private IEnumerator DoRotationClose()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(StartRotation);

        IsOpen = false;

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }


    private IEnumerator DoSlidingClose()
    {
        Vector3 endPosition = StartPosition;
        Vector3 startPosition = transform.position;
        float time = 0;
 
        IsOpen = false;

        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }
}
