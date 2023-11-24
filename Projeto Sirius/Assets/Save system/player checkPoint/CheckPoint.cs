using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using FMODUnity;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Color notSaved = Color.red;
    [SerializeField] private Color saved = Color.blue;
    [SerializeField]private SpriteRenderer sprite;

    [Header("sons")]
    [SerializeField] private StudioEventEmitter save_Sound;

    private void Start()
    {
        sprite.color = notSaved;
    }

    public void savePlayer(GameObject player)
    {
        SaveSystem.SavePlayer(player);

        sprite.color = saved;

        if (!save_Sound.IsPlaying())
        {
            save_Sound.Play();
        }

    }
}
