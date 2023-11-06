using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        //seta do gizmo
        Gizmos.color = Color.green;
        //topo
        Gizmos.DrawLine(new Vector3(transform.position.x + 0.5f, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x - 0.5f, transform.position.y + 1, transform.position.z));
        //barra lateral
        Gizmos.DrawLine(new Vector3(transform.position.x + 0.5f, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(transform.position.x - 0.5f, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z));
        //base cabeça
        Gizmos.DrawLine(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), new Vector3(transform.position.x - 0.75f, transform.position.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), new Vector3(transform.position.x + 0.75f, transform.position.y, transform.position.z));
        //seta
        Gizmos.DrawLine(new Vector3(transform.position.x - 0.75f, transform.position.y, transform.position.z), new Vector3(transform.position.x, transform.position.y-1, transform.position.z));
        Gizmos.DrawLine(new Vector3(transform.position.x + 0.75f, transform.position.y, transform.position.z), new Vector3(transform.position.x, transform.position.y-1, transform.position.z));
    }
    //spawn simples
    public bool SpawnPlayer(GameObject player, GameObject cam, PauseMenu menu)
    {
        GameObject local_player = Instantiate(player, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);

        local_player.GetComponent<QuimicoPlayer>().menuMorte = menu;

        cam.GetComponent<CinemachineVirtualCamera>().Follow = local_player.transform;
        cam.GetComponent<CinemachineVirtualCamera>().LookAt = local_player.transform;

        return local_player;
    }
    //spawn com Save
    public bool SpawnPlayer(GameObject player, PlayerData data, GameObject cam, PauseMenu menu)
    {
        GameObject local_PLayer = Instantiate(player, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);

        local_PLayer.GetComponent<QuimicoPlayer>().SetQuimicoAtual(data.quantidade_Aplicada);
        local_PLayer.GetComponent<QuimicoPlayer>().SetQuimico(data.quantidade_Guardada);
        local_PLayer.GetComponent<QuimicoPlayer>().menuMorte = menu;

        cam.GetComponent<CinemachineVirtualCamera>().Follow = local_PLayer.transform;
        cam.GetComponent<CinemachineVirtualCamera>().LookAt = local_PLayer.transform;

        return local_PLayer;
    }

}
