using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SaveManeger : MonoBehaviour
{
    [Header("Ponto de Spawn")]
    [SerializeField] private PlayerSpawn spawn;

    [Header("Prefab do Player")]
    [SerializeField] private GameObject player;

    [Header("Camera da Scena")]
    [SerializeField] private GameObject cam;

    [Header("Menu Pause")]
    [SerializeField] private PauseMenu menupause;

    [Header("Erase Data:")]
    [SerializeField] private bool erase = false;

    public PlayerData data;
    public GameObject m_player;

    private void Start()
    {
        if (VerifyConfig())
        {
            data = SaveSystem.LoadPlayer();

            //verifica se existe um save do player ja existente
            if (data == null)
            {   
                m_player = spawn.SpawnPlayer(player,cam,menupause);
            }
            else {

                if (data.scena_Atual == SceneManager.GetActiveScene().name)
                {
                    spawn.transform.position = new Vector3(data.loc_Atual[0], data.loc_Atual[1], spawn.transform.position.z);
                }
                m_player = spawn.SpawnPlayer(player,data,cam,menupause);
            }
        }

        SaveSystem.SavePlayer(m_player,SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        data = SaveSystem.LoadPlayer();

        if (erase)
        {
            SaveSystem.ErasePlayer();
            erase = false;
        }
    }

    //verifica se todos os requerimentos para carregar o player foram configurados
    private bool VerifyConfig()
    {
        bool configurado = true;

        if (!spawn)
        {
            Debug.LogError("Ponto de Spawn do player não configurado! \n favor configurar antes de continuar");
            configurado = false;
        }
        if (!player)
        {
            Debug.LogError("Prefab do player não configurado! \n favor configurar antes de continuar");
            configurado = false;
        }
        if (!cam)
        {
            Debug.LogError("Prefab da camera não configurado! \n favor configurar antes de continuar");
            configurado = false;
        }
        if (!menupause)
        {
            Debug.LogError("Prefab do Menu de pause não configurado! \n favor configurar antes de continuar");
            configurado = false;
        }

        return configurado;

    }
}
