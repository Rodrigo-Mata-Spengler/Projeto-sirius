using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanel : MonoBehaviour
{

    [SerializeField] private GameObject ArmarioFechado;
    [SerializeField] private GameObject MainOpcoesPanel;
    [SerializeField] private GameObject OpcoesPanel;
    [SerializeField] private GameObject ControlesPanel;
    [SerializeField] private GameObject GraficosPanel;
    [SerializeField] private GameObject SFXPanel;

    [SerializeField] private List<GameObject> paineisOpcoes= new List<GameObject>();

    private int PanelOpen = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackMainMenuPanel()
    {
        ArmarioFechado.SetActive(true);
       
    }

    public void DesligaPainel()
    {
        for(int i = 0; i<paineisOpcoes.Count; i++)
        {
            paineisOpcoes[i].SetActive(false);
        }
    }

    public void ParaControles()
    {
        DesligaPainel();


        ControlesPanel.SetActive(true);

        PanelOpen = 1;

    }
    public void ParaGraficos()
    {
        DesligaPainel();

        PanelOpen = 2;

        GraficosPanel.SetActive(true);
    }
    public void ParaSFX()
    {
        DesligaPainel();

        PanelOpen = 3;

        SFXPanel.SetActive(true);
    }

    public void ParaMainMenu()
    {
       

        ArmarioFechado.SetActive(true);
        MainOpcoesPanel.SetActive(false);
    }
}
