using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuimicoUI : MonoBehaviour
{
    [SerializeField] private Slider slide;
    [SerializeField] private QuimicoPlayer qPlayer;

    private void LateUpdate()
    {
        slide.value = qPlayer.GetQuimicoAtual() * -1;
    }
}
