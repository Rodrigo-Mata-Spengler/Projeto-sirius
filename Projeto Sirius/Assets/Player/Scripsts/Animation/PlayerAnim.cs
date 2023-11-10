using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public PlayerMoveStatus playerStatus;
    public MovimentoPlayer playermov;
    private Animator anim;
    private StatusMovimento status;
    private SpriteRenderer rend;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        TranslateStatus(playerStatus.GetStatus());

        switch (status)
        {
            case StatusMovimento.idle:
                anim.SetBool("Is_Walking", false);

                anim.SetBool("Is_Runing", false);

                anim.SetBool("Is_Jumping", false);

                anim.SetBool("Is_falling", false);

                anim.SetBool("Is_crouch", false);

                anim.SetBool("Is_Pushing", false);

                anim.SetBool("Is_Clibing", false);

                anim.SetBool("Is_grab", false);

                anim.SetBool("Is_Stealth_idle", false);

                anim.SetBool("Is_Clibing_idle", false);
                break;

            case StatusMovimento.caminhando:
                anim.SetBool("Is_Walking", true);
                break;
            case StatusMovimento.correndo:
                anim.SetBool("Is_Runing", true);
                break;
            case StatusMovimento.pulando:
                //anim.SetBool("Is_Walking", true);
                anim.SetBool("Is_Jumping", true);
                break;
            case StatusMovimento.caindo:
                anim.SetBool("Is_falling", true);
                break;
            case StatusMovimento.agachando:
                anim.SetBool("Is_crouch", true);
                anim.SetBool("Is_Stealth_idle", false);
                break;
            case StatusMovimento.agachado_idle:
                anim.SetBool("Is_Stealth_idle", true);
                break;
            case StatusMovimento.empurrando:
                anim.SetBool("Is_Pushing", true);
                break;
            case StatusMovimento.escalando:
                anim.SetBool("Is_Clibing", true);
                anim.SetBool("Is_Clibing_idle", false);
                break;
            case StatusMovimento.escalando_idle:
                anim.SetBool("Is_Clibing_idle", true);
                break;
            case StatusMovimento.agarrando:
                anim.SetBool("Is_grab", true);
                break;
        }

        if (playermov.LastInput() > 0)
        {
            rend.flipX = false;
        }else if(playermov.LastInput() < 0)
        {
            rend.flipX = true;
        }
    }


    private void TranslateStatus(float data)
    {
        switch (data)
        {
            case 0:
                status = StatusMovimento.idle;
                break;
            case 1:
                status = StatusMovimento.caminhando;
                break;
            case 2:
                status = StatusMovimento.correndo;
                break;
            case 3:
                status = StatusMovimento.pulando;
                break;
            case 4:
                status = StatusMovimento.caindo;
                break;
            case 5:
                status = StatusMovimento.agachando;
                break;
            case 6:
                status = StatusMovimento.empurrando;
                break;
            case 7:
                status = StatusMovimento.escalando;
                break;
            case 8:
                status = StatusMovimento.agarrando;
                break;
            case 9:
                status = StatusMovimento.agachado_idle;
                break;
            case 10:
                status = StatusMovimento.escalando_idle;
                break;
        }
    }
}
