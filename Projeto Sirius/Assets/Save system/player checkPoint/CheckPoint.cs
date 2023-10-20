using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Color notSaved = Color.red;
    [SerializeField] private Color saved = Color.blue;
    [SerializeField]private SpriteRenderer sprite;

    private void Start()
    {
        sprite.color = notSaved;
    }

    public void savePlayer(GameObject player)
    {
        SaveSystem.SavePlayer(player);

        sprite.color = saved;
    }
}
