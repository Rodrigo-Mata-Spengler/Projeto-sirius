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
        Gizmos.DrawLine(new Vector3(transform.position.x + 0.5f, transform.position.y + 2, transform.position.z), new Vector3(transform.position.x - 0.5f, transform.position.y + 2, transform.position.z));
        //barra lateral
        Gizmos.DrawLine(new Vector3(transform.position.x + 0.5f, transform.position.y + 2, transform.position.z), new Vector3(transform.position.x + 0.5f, transform.position.y+1, transform.position.z));
        Gizmos.DrawLine(new Vector3(transform.position.x - 0.5f, transform.position.y + 2, transform.position.z), new Vector3(transform.position.x - 0.5f, transform.position.y+1, transform.position.z));
        //base cabeça
        Gizmos.DrawLine(new Vector3(transform.position.x - 0.5f, transform.position.y+1, transform.position.z), new Vector3(transform.position.x - 0.75f, transform.position.y+1, transform.position.z));
        Gizmos.DrawLine(new Vector3(transform.position.x + 0.5f, transform.position.y+1, transform.position.z), new Vector3(transform.position.x + 0.75f, transform.position.y+1, transform.position.z));
        //seta
        Gizmos.DrawLine(new Vector3(transform.position.x - 0.75f, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x, transform.position.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(transform.position.x + 0.75f, transform.position.y + 1, transform.position.z), new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }
    //spawn simples
    public bool SpawnPlayer(GameObject player)
    {
        return Instantiate(player,new Vector3(transform.position.x, transform.position.y+1, transform.position.z), transform.rotation);
    }
    //spawn com Save
    public bool SpawnPlayer(GameObject player, PlayerData data)
    {
        GameObject local_PLayer = Instantiate(player, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);

        local_PLayer.GetComponent<QuimicoPlayer>().SetQuimicoAtual(data.quantidade_Aplicada);
        local_PLayer.GetComponent<QuimicoPlayer>().SetQuimico(data.quantidade_Guardada);

        return local_PLayer;
    }

}
