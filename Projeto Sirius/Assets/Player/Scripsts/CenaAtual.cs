using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaAtual : MonoBehaviour
{
    public string cena;

    private void OnLevelWasLoaded(int level)
    {
        cena = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        cena = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        cena = SceneManager.GetActiveScene().name;
    }
}
