using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanel : MonoBehaviour
{

    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject MainOpcoesPanel;
    [SerializeField] private GameObject OpcoesPanel;
    [SerializeField] private GameObject ControlesPanel;
    [SerializeField] private GameObject GraficosPanel;
    [SerializeField] private GameObject SFXPanel;

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
        OpcoesPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
       
    }

    public void ParaOpçoes()
    {
        switch(PanelOpen)
        {
            case 1:
                ControlesPanel.SetActive(false);
                break;

            case 2:
                GraficosPanel.SetActive(false);
                break;

            case 3:
                SFXPanel.SetActive(false);
                break;

        }
        OpcoesPanel.SetActive(true);
        PanelOpen = 0;
    }

    public void ParaControles()
    {
        OpcoesPanel.SetActive(false);
        ControlesPanel.SetActive(true);

        PanelOpen = 1;

    }
    public void ParaGraficos()
    {
        PanelOpen = 2;
        OpcoesPanel.SetActive(false);
        GraficosPanel.SetActive(true);
    }
    public void ParaSFX()
    {
        PanelOpen = 3;
        OpcoesPanel.SetActive(false);
        SFXPanel.SetActive(true);
    }

    public void ParaMainMenu()
    {
        MainMenuPanel.SetActive(true);
        MainOpcoesPanel.SetActive(false);
    }
}
