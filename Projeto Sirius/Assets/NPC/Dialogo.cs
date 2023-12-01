using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using UnityEngine.InputSystem;
using System.Threading;

public class Dialogo : MonoBehaviour
{
    [Header("UI elements:")]
    [SerializeField] private GameObject dialogue_Panel;
    [SerializeField] private TMP_Text texto;

    [Header("Dialogue:")]
    [TextArea]
    [SerializeField] private string[] dialogue;
    private int dialogueSize = 0;
    private int dialogueSize_Atual = 0;

    [Header("Camera Focus:")]
    [SerializeField] private CinemachineVirtualCamera cam;

    [Header("Player:")]
    [SerializeField] private string playerTag;
    private QuimicoPlayer playerQui;
    private MovimentoPlayer playerMov;
    private PlayerMoveStatus playerStatus;
    private PlayerInput playerInput;
    [SerializeField]private PlayerInput input;

    private bool startDialogue = false;

    [SerializeField]private SphereCollider barreira;

    [Header("Delay:")]
    [SerializeField] private float delay = 0;
    private float delay_tempo = 0;
    
    private void Start()
    {
        dialogue_Panel.SetActive(false);
        dialogueSize = dialogue.Length;
        input.enabled = false;
    }

    public void OnInteracao(InputAction.CallbackContext context)
    {
        if (context.performed && delay_tempo <= Time.time && dialogueSize_Atual < dialogueSize+1 && startDialogue)
        {
            delay_tempo = delay + Time.time;

            ShowText(dialogue[dialogueSize_Atual]);
            dialogueSize_Atual++;
            if (dialogueSize_Atual == dialogueSize)
            {
                startDialogue = false;
            }

        }else if (dialogueSize_Atual == dialogueSize && startDialogue == false && delay_tempo <= Time.time)
        {
            playerMov.enabled = true;
            playerQui.desligarCadencia = false;
            playerInput.enabled = true;

            dialogue_Panel.SetActive(false);

            cam.Priority = 9;

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            barreira.enabled = false;

            playerMov = other.gameObject.GetComponent<MovimentoPlayer>();
            playerQui = other.gameObject.GetComponent<QuimicoPlayer>();
            playerStatus = other.gameObject.GetComponent<PlayerMoveStatus>();
            playerInput = other.gameObject.GetComponent<PlayerInput>();

            playerStatus.SetStatus(StatusMovimento.idle);

            //playerMov.enabled = false;
            playerQui.desligarCadencia = true;
            playerInput.enabled = false;

            dialogue_Panel.SetActive(true);

            startDialogue = true;

            ShowText(dialogue[dialogueSize_Atual]);
            dialogueSize_Atual++;

            delay_tempo = delay + Time.time;

            input.enabled = true;

            cam.Priority = 11;
        }
    }

    private void ShowText(string textoDialogo)
    {
        texto.text = textoDialogo;
    }


}
