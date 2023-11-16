using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [Header("Tutorial Panel:")]
    [SerializeField] private TutorialManager manager;
    [SerializeField] private int tutorialNum = 0;

    [Header("Player tag")]
    [SerializeField] private string playerTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            manager.OpenTutorial(tutorialNum);
            Destroy(gameObject);
        }
    }
}
