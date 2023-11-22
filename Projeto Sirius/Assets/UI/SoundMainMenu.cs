using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMainMenu : MonoBehaviour
{
    private void Start()
    {
        SoundBolha();
    }

    public void SoundBolha()
    {
        //AudioManager.instance.InitializeMusic(FMODEvents.instance.BolhasMenu);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.BolhasMenu,transform.position);
    }
}
