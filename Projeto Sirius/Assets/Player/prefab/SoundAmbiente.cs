using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;

public class SoundAmbiente : MonoBehaviour
{
    public StudioEventEmitter som;

    private void Update()
    {
        if (!som.IsPlaying())
        {
            som.Play();
        }
    }
}
