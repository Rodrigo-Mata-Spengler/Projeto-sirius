using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    [Header("Painel fade:")]
    [SerializeField] private GameObject fadePanel;

    [Header("Tutorial Panels:")]
    [SerializeField] private GameObject[] tutorialPanels;

    [Header("Delay Input:")]
    [SerializeField] private float delayInput = 0;
    private float delayTime = 0;

    private void Start()
    {
        fadePanel.SetActive(false);

        foreach (var item in tutorialPanels)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void OpenTutorial(int Value)
    {
        Value -= 1;

        Time.timeScale = 0;

        fadePanel.SetActive(false);
        tutorialPanels[Value].SetActive(true);

        delayTime = delayInput + Time.realtimeSinceStartup;

    }

    public void OnCloseAll(InputAction.CallbackContext context)
    {
        if (delayTime < Time.realtimeSinceStartup)
        {
            fadePanel.SetActive(false);

            foreach (var item in tutorialPanels)
            {
                item.gameObject.SetActive(false);
            }

            Time.timeScale = 1;
        }
    }
}
