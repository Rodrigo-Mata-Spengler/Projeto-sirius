using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Folha : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI nome;
    [SerializeField] public TextMeshProUGUI idade;
    [SerializeField] public TextMeshProUGUI Descrição;
    [SerializeField] public TextMeshProUGUI Pontuação;
    public Image Cordão;



    public void ChangeColorRed()
    {
        Cordão.color = Color.red;
    }
    public void ChangeColorYellow()
    {
        Cordão.color = Color.yellow;
    }
    public void ChangeColorGreem()
    {
        Cordão.color = Color.green;
    }
    public void ChangeColorBlue()
    {
        Cordão.color = Color.blue;
    }
}
