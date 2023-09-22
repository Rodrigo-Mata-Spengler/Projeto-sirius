using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Folha : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI nome;
    [SerializeField] public TextMeshProUGUI idade;
    [SerializeField] public TextMeshProUGUI Descri��o;
    [SerializeField] public TextMeshProUGUI Pontua��o;
    public Image Cord�o;



    public void ChangeColorRed()
    {
        Cord�o.color = Color.red;
    }
    public void ChangeColorYellow()
    {
        Cord�o.color = Color.yellow;
    }
    public void ChangeColorGreem()
    {
        Cord�o.color = Color.green;
    }
    public void ChangeColorBlue()
    {
        Cord�o.color = Color.blue;
    }
}
