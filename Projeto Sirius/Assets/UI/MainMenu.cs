using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string FirstScene;

    public GameObject ArmarioFechado;
    public GameObject OpcoesPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continuar()
    {

    }

    public void NovoJogo()
    {
        SceneManager.LoadScene(FirstScene);
    }
    public void Opcoes()
    {
        ArmarioFechado.SetActive(false);
        OpcoesPanel.SetActive(true);

    }

    public void Quit()
    {
        Application.Quit();
    }

}
