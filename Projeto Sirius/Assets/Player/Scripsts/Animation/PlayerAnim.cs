using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerAnim : MonoBehaviour
{
    public PlayerMoveStatus playerStatus;
    public MovimentoPlayer playermov;
    public QuimicoPlayer playerQuimico;
    public LedgeDetect ledge;
    private Animator anim;
    private StatusMovimento status_Movimento;
    private Statusquimico status_Quimico;
    private SpriteRenderer rend;

    private float temp_anim_bater = .1f;
    private float temp_anim_bater_time = 0;
    private bool morte = false;

    private bool empurrando = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!morte)
        {
            empurrando = false;

            //Animação do movimento
            TranslateStatusMov(playerStatus.GetStatus());

            switch (status_Movimento)
            {
                case StatusMovimento.idle:
                    anim.SetBool("Is_Walking", false);

                    anim.SetBool("Is_Runing", false);

                    anim.SetBool("Is_Jumping", false);

                    anim.SetBool("Is_falling", false);

                    anim.SetBool("Is_crouch", false);

                    anim.SetBool("Is_Clibing", false);

                    anim.SetBool("Is_grab", false);

                    anim.SetBool("Is_Stealth_idle", false);

                    anim.SetBool("Is_Clibing_idle", false);

                    anim.SetBool("Is_Abstinencia", false);

                    anim.SetBool("Is_empurrar", false);

                    anim.SetBool("Is_puxar", false);
                    break;
                case StatusMovimento.caminhando:
                    anim.SetBool("Is_Walking", true);

                    anim.SetBool("Is_Runing", false);

                    anim.SetBool("Is_Jumping", false);

                    anim.SetBool("Is_falling", false);

                    anim.SetBool("Is_crouch", false);

                    anim.SetBool("Is_Clibing", false);

                    anim.SetBool("Is_grab", false);

                    anim.SetBool("Is_Stealth_idle", false);

                    anim.SetBool("Is_Clibing_idle", false);

                    anim.SetBool("Is_Abstinencia", false);

                    anim.SetBool("Is_empurrar", false);

                    anim.SetBool("Is_puxar", false);
                    break;
                case StatusMovimento.correndo:
                    anim.SetBool("Is_Walking", false);

                    anim.SetBool("Is_Runing", true);

                    anim.SetBool("Is_Jumping", false);

                    anim.SetBool("Is_falling", false);

                    anim.SetBool("Is_crouch", false);

                    anim.SetBool("Is_Clibing", false);

                    anim.SetBool("Is_grab", false);

                    anim.SetBool("Is_Stealth_idle", false);

                    anim.SetBool("Is_Clibing_idle", false);

                    anim.SetBool("Is_Abstinencia", false);

                    anim.SetBool("Is_empurrar", false);

                    anim.SetBool("Is_puxar", false);
                    break;
                case StatusMovimento.pulando:
                    anim.SetBool("Is_Walking", false);

                    anim.SetBool("Is_Runing", false);

                    anim.SetBool("Is_Jumping", true);

                    anim.SetBool("Is_falling", false);

                    anim.SetBool("Is_crouch", false);

                    anim.SetBool("Is_Clibing", false);

                    anim.SetBool("Is_grab", false);

                    anim.SetBool("Is_Stealth_idle", false);

                    anim.SetBool("Is_Clibing_idle", false);

                    anim.SetBool("Is_Abstinencia", false);

                    anim.SetBool("Is_empurrar", false);

                    anim.SetBool("Is_puxar", false);
                    break;
                case StatusMovimento.caindo:
                    anim.SetBool("Is_Walking", false);

                    anim.SetBool("Is_Runing", false);

                    anim.SetBool("Is_Jumping", false);

                    anim.SetBool("Is_falling", true);

                    anim.SetBool("Is_crouch", false);

                    anim.SetBool("Is_Clibing", false);

                    anim.SetBool("Is_grab", false);

                    anim.SetBool("Is_Stealth_idle", false);

                    anim.SetBool("Is_Clibing_idle", false);

                    anim.SetBool("Is_Abstinencia", false);

                    anim.SetBool("Is_empurrar", false);

                    anim.SetBool("Is_puxar", false);

                    break;
                case StatusMovimento.agachando:
                    anim.SetBool("Is_Walking", false);

                    anim.SetBool("Is_Runing", false);

                    anim.SetBool("Is_Jumping", false);

                    anim.SetBool("Is_falling", false);

                    anim.SetBool("Is_crouch", true);

                    anim.SetBool("Is_Clibing", false);

                    anim.SetBool("Is_grab", false);

                    anim.SetBool("Is_Stealth_idle", false);

                    anim.SetBool("Is_Clibing_idle", false);

                    anim.SetBool("Is_Abstinencia", false);

                    anim.SetBool("Is_empurrar", false);

                    anim.SetBool("Is_puxar", false);
                    break;
                case StatusMovimento.agachado_idle:
                    anim.SetBool("Is_Walking", false);

                    anim.SetBool("Is_Runing", false);

                    anim.SetBool("Is_Jumping", false);

                    anim.SetBool("Is_falling", false);

                    anim.SetBool("Is_crouch", false);

                    anim.SetBool("Is_Clibing", false);

                    anim.SetBool("Is_grab", false);

                    anim.SetBool("Is_Stealth_idle", true);

                    anim.SetBool("Is_Clibing_idle", false);

                    anim.SetBool("Is_Abstinencia", false);

                    anim.SetBool("Is_empurrar", false);

                    anim.SetBool("Is_puxar", false);
                    break;
                case StatusMovimento.empurrando:
                    anim.SetBool("Is_Walking", false);

                    anim.SetBool("Is_Runing", false);

                    anim.SetBool("Is_Jumping", false);

                    anim.SetBool("Is_falling", false);

                    anim.SetBool("Is_crouch", false);

                    anim.SetBool("Is_Clibing", false);

                    anim.SetBool("Is_grab", false);

                    anim.SetBool("Is_Stealth_idle", false);

                    anim.SetBool("Is_Clibing_idle", false);

                    anim.SetBool("Is_Abstinencia", false);

                    if (playermov.LastInput() > 0)
                    {
                        anim.SetBool("Is_empurrar",true);
                        anim.SetBool("Is_puxar", false);
                    }
                    else if (playermov.LastInput() < 0)
                    {
                        anim.SetBool("Is_empurrar", false);
                        anim.SetBool("Is_puxar", true);
                    }

                    empurrando = true;
                    break;
                case StatusMovimento.escalando:
                    anim.SetBool("Is_Walking", false);

                    anim.SetBool("Is_Runing", false);

                    anim.SetBool("Is_Jumping", false);

                    anim.SetBool("Is_falling", false);

                    anim.SetBool("Is_crouch", false);

                    anim.SetBool("Is_Clibing", true);

                    anim.SetBool("Is_grab", false);

                    anim.SetBool("Is_Stealth_idle", false);

                    anim.SetBool("Is_Clibing_idle", false);

                    anim.SetBool("Is_Abstinencia", false);

                    anim.SetBool("Is_empurrar", false);

                    anim.SetBool("Is_puxar", false);
                    break;
                case StatusMovimento.escalando_idle:
                    anim.SetBool("Is_Walking", false);

                    anim.SetBool("Is_Runing", false);

                    anim.SetBool("Is_Jumping", false);

                    anim.SetBool("Is_falling", false);

                    anim.SetBool("Is_crouch", false);

                    anim.SetBool("Is_Clibing", false);

                    anim.SetBool("Is_grab", false);

                    anim.SetBool("Is_Stealth_idle", false);

                    anim.SetBool("Is_Clibing_idle", true);

                    anim.SetBool("Is_Abstinencia", false);

                    anim.SetBool("Is_empurrar", false);

                    anim.SetBool("Is_puxar", false);
                    break;
                case StatusMovimento.agarrando:
                    anim.SetBool("Is_Walking", false);

                    anim.SetBool("Is_Runing", false);

                    anim.SetBool("Is_Jumping", false);

                    anim.SetBool("Is_falling", false);

                    anim.SetBool("Is_crouch", false);

                    anim.SetBool("Is_Clibing", false);

                    anim.SetBool("Is_grab", true);

                    anim.SetBool("Is_Stealth_idle", false);

                    anim.SetBool("Is_Clibing_idle", false);

                    anim.SetBool("Is_Abstinencia", false);

                    anim.SetBool("Is_empurrar", false);

                    anim.SetBool("Is_puxar", false);
                    break;
            }

            //Animação do Quimico
            TranlateStatusQuimico(playerQuimico.StatusTranslator());

            switch (status_Quimico)
            {
                case Statusquimico.Abstinencia:

                    if (status_Movimento != StatusMovimento.idle && status_Movimento != StatusMovimento.caindo)
                    {
                        anim.SetBool("Is_Walking", false);

                        anim.SetBool("Is_Runing", false);

                        anim.SetBool("Is_Jumping", false);

                        anim.SetBool("Is_falling", false);

                        anim.SetBool("Is_crouch", false);

                        anim.SetBool("Is_Clibing", false);

                        anim.SetBool("Is_grab", false);

                        anim.SetBool("Is_Stealth_idle", false);

                        anim.SetBool("Is_Clibing_idle", false);

                        anim.SetBool("Is_Abstinencia", true);
                    }
                    break;
                case Statusquimico.Normal:

                    break;
                case Statusquimico.Overdose:
                    break;
            }

            if (ledge.IsLedge())
            {
                anim.SetBool("Is_Walking", false);

                anim.SetBool("Is_Runing", false);

                anim.SetBool("Is_Jumping", false);

                anim.SetBool("Is_falling", false);

                anim.SetBool("Is_crouch", false);

                anim.SetBool("Is_Clibing", false);

                anim.SetBool("Is_grab", true);

                anim.SetBool("Is_Stealth_idle", false);

                anim.SetBool("Is_Clibing_idle", false);

                anim.SetBool("Is_Abstinencia", false);

                anim.SetBool("Is_empurrar", false);

                anim.SetBool("Is_puxar", false);
            }

            if (playermov.LastInput() > 0 && !empurrando)
            {
                rend.flipX = false;
            }
            else if (playermov.LastInput() < 0 && !empurrando)
            {
                rend.flipX = true;
            }

            if (temp_anim_bater_time <= Time.time)
            {
                anim.ResetTrigger("Trig_baterParede");
            }
        }

    }


    private void TranslateStatusMov(float data)
    {
        switch (data)
        {
            case 0:
                status_Movimento = StatusMovimento.idle;
                break;
            case 1:
                status_Movimento = StatusMovimento.caminhando;
                break;
            case 2:
                status_Movimento = StatusMovimento.correndo;
                break;
            case 3:
                status_Movimento = StatusMovimento.pulando;
                break;
            case 4:
                status_Movimento = StatusMovimento.caindo;
                break;
            case 5:
                status_Movimento = StatusMovimento.agachando;
                break;
            case 6:
                status_Movimento = StatusMovimento.empurrando;
                break;
            case 7:
                status_Movimento = StatusMovimento.escalando;
                break;
            case 8:
                status_Movimento = StatusMovimento.agarrando;
                break;
            case 9:
                status_Movimento = StatusMovimento.agachado_idle;
                break;
            case 10:
                status_Movimento = StatusMovimento.escalando_idle;
                break;
        }
    }

    private void TranlateStatusQuimico(float data)
    {
        switch (data)
        {
            case 0:
                status_Quimico = Statusquimico.Abstinencia;
                break;
            case 1:
                status_Quimico = Statusquimico.Normal;
                break;
            case 2:
                status_Quimico = Statusquimico.Overdose;
                break;
        }
    }

    public void BaterParede()
    {
        anim.SetTrigger("Trig_baterParede");

        temp_anim_bater_time = temp_anim_bater + Time.time;
    }

    public void Morte()
    {
        morte = true;

        playermov.enabled = false;

        anim.SetBool("Is_Walking", false);

        anim.SetBool("Is_Runing", false);

        anim.SetBool("Is_Jumping", false);

        anim.SetBool("Is_falling", false);

        anim.SetBool("Is_crouch", false);

        anim.SetBool("Is_Clibing", false);

        anim.SetBool("Is_grab", false);

        anim.SetBool("Is_Stealth_idle", false);

        anim.SetBool("Is_Clibing_idle", false);

        anim.SetBool("Is_Abstinencia", false);

        anim.SetTrigger("Trig_Morrendo");
        
    }

    public void TempoCongelado()
    {
        Time.timeScale = 0;
    }

    public void UsarQuimico()
    {
        anim.SetBool("Is_Walking", false);

        anim.SetBool("Is_Runing", false);

        anim.SetBool("Is_Jumping", false);

        anim.SetBool("Is_falling", false);

        anim.SetBool("Is_crouch", false);

        anim.SetBool("Is_Clibing", false);

        anim.SetBool("Is_grab", false);

        anim.SetBool("Is_Stealth_idle", false);

        anim.SetBool("Is_Clibing_idle", false);

        anim.SetBool("Is_Abstinencia", false);

        anim.SetTrigger("trig_Use_chem");
    }
}
