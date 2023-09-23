using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWallTrigger : MonoBehaviour
{
    [SerializeField]
    private DestructibleWall Wall;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovimento>(out PlayerMovimento controller))
        {
            if(controller.velocidade == controller.velocidadeOverdoseCorrendo && !Wall.DoOnce)
            {
                Wall.BreakWall();
            }
        }
    }

}
