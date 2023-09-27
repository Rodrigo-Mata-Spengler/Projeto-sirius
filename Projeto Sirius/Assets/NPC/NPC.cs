using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    [Header("On UI elements")]
    [SerializeField] TextMeshProUGUI conversationText;// the obj that contains the text component

    [Header("The text")]
    [TextAreaAttribute] //give more space to write
    [SerializeField] private string[] NpcWords;// array of paragraph

    [Header("Trigger")]
    private BoxCollider trigger; // the box collider trigger
    public bool playerDetected = false; //variable to player detection
    private bool havingConversation = false; // variable to see if the paragraph is still been writing
    private bool nextFrase = false;//variable that checks if the player can go to the next paragraph

    [Header("Typing")]
    [Space]
    private bool endText = true;
    public int textLocation = 0;// get whi  ch one of the paragraphs or enabled

    private PlayerMovimento Player;
    private void Start()
    {
        trigger = this.GetComponent<BoxCollider>();
    }

    private void Update()
    {


        if (playerDetected)
        {
            NextLineAndStop();
        }

    }
    private void NextLineAndStop()
    {
        if (Input.GetButtonDown("Interagir") && textLocation < NpcWords.Length)
        {
            StopAllCoroutines();
            textLocation += 1;
            Debug.Log("aquiii");
            conversationText.text = NpcWords[textLocation];
        }
        if(textLocation >= NpcWords.Length)
        {
            Player.enabled = true;
            trigger.enabled = false;
            conversationText.text = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerMovimento>(out PlayerMovimento playermovimento))
        {
            playerDetected = true;
            Player = playermovimento;
            conversationText.text = NpcWords[0];
            textLocation = 0;
            playermovimento.enabled = false;
        }
    }
}
