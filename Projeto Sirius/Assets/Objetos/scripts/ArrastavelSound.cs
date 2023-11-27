using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ArrastavelSound : MonoBehaviour
{
    [Header("Son")]
    [SerializeField] private StudioEventEmitter arrastar_Sound;

    private void Update()
    {
        if (transform.GetComponent<Rigidbody>().velocity.x > 0)
        {
            if (arrastar_Sound.IsPlaying())
            {
                arrastar_Sound.Play();
            }
        }
        else
        {
            if (arrastar_Sound.IsPlaying())
            {
                arrastar_Sound.Stop();
            }
        }
    }
}
