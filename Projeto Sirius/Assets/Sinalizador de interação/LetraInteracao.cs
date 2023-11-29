using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LetraInteracao : MonoBehaviour
{
    [SerializeField] private Text textoBiding;
    [SerializeField] private TextMeshPro textoDisplay;

    private void OnEnable()
    {
        textoDisplay.text = textoBiding.text;
    }
}
