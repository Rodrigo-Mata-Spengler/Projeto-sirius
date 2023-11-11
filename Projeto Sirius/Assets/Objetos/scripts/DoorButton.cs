using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{

    [SerializeField] private Door[] Door;

    [SerializeField] private bool timer = false;
    [SerializeField] private float tempoLigado = 0;

    [SerializeField] private Animator AlavancaPivotAnimator;
    private float tempoFechar = 0;

    private void Update()
    {
        if (timer)
        {
            if (tempoFechar <= Time.time)
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
        if (!timer)
        {
            for (int i = 0; i < Door.Length; i++)
            {
                if (!Door[i].IsOpen)
                {
                    Door[i].Open(Player.transform.position);
                    AlavancaPivotAnimator.SetBool("Apertou", true);

                }
            }
        }else
        {
            tempoFechar = tempoLigado + Time.time;
        }

        
    }
}
