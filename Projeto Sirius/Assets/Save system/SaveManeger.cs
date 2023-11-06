using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
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

    private PlayerData data;

    private void Start()
    {
        if (VerifyConfig())
        {
            //verifica se existe um save do player ja existente
            if (data == null)
            {   
                spawn.SpawnPlayer(player,cam,menupause);
            }else {
                spawn.transform.position = new Vector3(data.loc_Atual[0], data.loc_Atual[1],spawn.transform.position.z);

                spawn.SpawnPlayer(player,data,cam,menupause);
            }
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
