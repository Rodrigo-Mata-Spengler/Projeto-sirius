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

    private PlayerData data;

    private void Start()
    {
        if (VerifyConfig())
        {
            //verifica se existe um save do player ja existente
            data = SaveSystem.LoadPlayer();
            if (data == null)
            {
                Debug.Log(player.GetComponent<QuimicoPlayer>().getQuimico());
                
                spawn.SpawnPlayer(player);
            }else {
                spawn.transform.position = new Vector3(data.loc_Atual[0], data.loc_Atual[1],spawn.transform.position.z);

                spawn.SpawnPlayer(player,data);
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

        return configurado;

    }
}
