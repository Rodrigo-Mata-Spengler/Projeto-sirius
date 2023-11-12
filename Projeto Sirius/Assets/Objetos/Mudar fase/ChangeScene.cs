using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [Header("Nome da próxima fase:")]
    [SerializeField] private string proxFase;

    [Header("Player Tag")]
    [SerializeField] private string tagPlayer;

    [Header("Salvar")]
    [SerializeField] private bool salvar = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            SceneManager.LoadScene(proxFase);
            if (salvar)
            {
                SaveSystem.SavePlayer(other.gameObject);
            }
        }
    }
}
