using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Ambience SFX")]
    [field: SerializeField] public EventReference ambience { get; private set; }


    [field: Header("Music SFX")]
    [field: SerializeField] public EventReference Music { get; private set; }


    [field: Header("Interface SFX")]
    [field: SerializeField] public EventReference BolhasMenu { get; private set; }
    [field: SerializeField] public EventReference EngrenagensMenu { get; private set; }
    [field: SerializeField] public EventReference InterruptorMenu { get; private set; }
    [field: SerializeField] public EventReference PortaFechando { get; private set; }
    [field: SerializeField] public EventReference PortaRanger { get; private set; }
    [field: SerializeField] public EventReference Confirmacao { get; private set; }


    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference Caminhando { get; private set; }
    [field: SerializeField] public EventReference Correndo { get; private set; }
    [field: SerializeField] public EventReference Pulo { get; private set; }
    [field: SerializeField] public EventReference Agachado { get; private set; }
    [field: SerializeField] public EventReference Escalando { get; private set; }
    [field: SerializeField] public EventReference EscalandoCorda { get; private set; }
    [field: SerializeField] public EventReference Desmaiando { get; private set; }
    [field: SerializeField] public EventReference Morrendo { get; private set; }
    [field: SerializeField] public EventReference BatendoGaiola { get; private set; }


    [field: Header("Player quimico SFX")]
    [field: SerializeField] public EventReference Abstinencia { get; private set; }
    [field: SerializeField] public EventReference Overdose { get; private set; }
    [field: SerializeField] public EventReference UsandoQuimico { get; private set; }


    [field: Header("Cientista SFX")]
    [field: SerializeField] public EventReference CientistaCaminhando{ get; private set; }

    
    [field: Header("Mundo SFX")]
    [field: SerializeField] public EventReference Alavanca { get; private set; }
    [field: SerializeField] public EventReference Alcapao { get; private set; }
    [field: SerializeField] public EventReference ApagandoLuz { get; private set; }
    [field: SerializeField] public EventReference PlacaPresao { get; private set; }
    [field: SerializeField] public EventReference ArrastandoObjeto { get; private set; }
    [field: SerializeField] public EventReference ObjetoMetalicoCaindo { get; private set; }
    [field: SerializeField] public EventReference QuebrandoParede { get; private set; }
    [field: SerializeField] public EventReference VidroQuebrando { get; private set; }


    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found More than one Audio Manager in the scene");
        }
        instance = this;
    }
}
