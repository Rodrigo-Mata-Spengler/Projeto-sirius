using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string FirstScene;

    public GameObject ArmarioFechado;
    public GameObject OpcoesPanel;

    public Button continuar;
    private PlayerData data;

    private void Start()
    {
        data = SaveSystem.LoadPlayer();

        if (data != null)
        {
            continuar.interactable = true;
        }
        else
        {
            continuar.interactable = false;
        }
    }
    public void ContinuarJogo()
    {
        SceneManager.LoadScene(data.scena_Atual);
    }

    public void NovoJogo()
    {
        SaveSystem.ErasePlayer();
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
