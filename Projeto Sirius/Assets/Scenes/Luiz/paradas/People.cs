using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sangue { A, B, OP, ABP, ON}
public enum Doenca { Diabetes, Anemia, Diarreia}
public enum Pulsera { Verde, Azul, Amarelo, Vermelho, Sem }
public class People : MonoBehaviour
{
    [Header("Descrição")]
    public string nome;
    public string altura;
    public string idade;
    [TextArea]
    public string descricaoDosProblemas;
    [SerializeField] private Sangue sangue;
    [SerializeField] private Doenca doenca;
    [SerializeField] public Pulsera pulsera;

    [Header("PulseraCerta")]
    [SerializeField] public Pulsera PulseraCerta;

}
