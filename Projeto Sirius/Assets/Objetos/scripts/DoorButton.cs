using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DoorButton : MonoBehaviour
{

    [SerializeField] private Door[] Door;

    [SerializeField] private bool timer = false;
    private bool ctrl = false;
    [SerializeField] private float tempoLigado = 0;

    [SerializeField] private Animator AlavancaPivotAnimator;
    private float tempoFechar = 0;

    [Header("Sons")]
    [SerializeField] private StudioEventEmitter alavanca_Sound;

    private void Update()
    {
        if (timer)
        {
            if (tempoFechar <= Time.time && ctrl)
            {
                for (int i = 0; i < Door.Length; i++)
                {
                    if (!Door[i].IsOpen)
                    {
                        Door[i].Close();

                    }
                }
            }
        }
    }

    public void OpenDoor(Transform Player)
    {

        for (int i = 0; i < Door.Length; i++)
        {
            if (!Door[i].IsOpen)
            {
                Door[i].Open(Player.transform.position);
                AlavancaPivotAnimator.SetBool("Apertou", true);

            }
        }

        if (!alavanca_Sound.IsPlaying())
        {
            alavanca_Sound.Play();
        }

        if (timer)
        {
            tempoFechar = tempoLigado + Time.time;
            ctrl = true;
        }

        
    }
}
