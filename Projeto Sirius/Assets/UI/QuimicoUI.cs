using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuimicoUI : MonoBehaviour
{
    [SerializeField] private Slider slide;
    [SerializeField] private QuimicoPlayer qPlayer;
    [SerializeField] private TMP_Text texto;
    private void LateUpdate()
    {
        if (qPlayer == null)
        {
            qPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<QuimicoPlayer>();
        }
        if (slide)
        {
            slide.value = qPlayer.GetQuimicoAtual() * -1;
        }
        else if (texto)
        {
            texto.text = qPlayer.getQuimico().ToString();
        }

        
    }
}
