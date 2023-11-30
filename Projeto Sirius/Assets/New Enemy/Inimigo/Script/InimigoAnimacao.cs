using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAnimacao : MonoBehaviour
{
    [Header("Animador :")]
    [SerializeField] private Animator anim;

    [SerializeField] private SpriteRenderer rend;

    [Header("Énemy Controler :")]
    [SerializeField] private EnemyControler enemy;
    [SerializeField] private EnemyStatus status;

    private void AtualizarStatus()
    {
        status =  enemy.GetStatus();
    }

    private void Update()
    {
        AtualizarStatus();

        switch (status)
        {
            case EnemyStatus.idle:
                anim.SetBool("Is_Walking", false);
                anim.SetBool("Is_Procurand", false);
                break;
            case EnemyStatus.movendo:
                anim.SetBool("Is_Walking", true);
                anim.SetBool("Is_Procurand", false);
                break;
            case EnemyStatus.Atraido:
                anim.SetBool("Is_Walking", true);
                anim.SetBool("Is_Procurand", false);
                break;
            case EnemyStatus.procurando:
                anim.SetBool("Is_Walking", false);
                anim.SetBool("Is_Procurand", true);
                break;
        }

        

        if (gameObject.GetComponent<Rigidbody>().velocity.x > 0 )
        {
            rend.flipX = false;
        }
        else if (gameObject.GetComponent<Rigidbody>().velocity.x < 0)
        {
            rend.flipX = true;
        }
    }
}
