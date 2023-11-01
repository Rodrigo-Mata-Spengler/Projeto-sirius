using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestructibleWallTrigger : MonoBehaviour
{
    [SerializeField]
    private DestructibleWall Wall;

    [SerializeField] private bool socar;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<QuimicoPlayer>(out QuimicoPlayer qPlayer))
        {
            Debug.Log("aquii");
            if (socar && !Wall.DoOnce && qPlayer.GetQuimicoAtual() >= qPlayer.GetAbstinencia())
            {
                Wall.BreakWall();
           
            }
        }
    }

    public void OnInteracao(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            socar = true;
        }
        else if (context.canceled)
        {
            socar = false;
        }
    }


}
