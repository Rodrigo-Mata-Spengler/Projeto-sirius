using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuimicoUi : MonoBehaviour
{
    [SerializeField] private QuimicoPlayer player;
    [SerializeField]private TMP_Text texto;

    private void LateUpdate()
    {
        texto.text = player.getQuimico().ToString();
    }
}
