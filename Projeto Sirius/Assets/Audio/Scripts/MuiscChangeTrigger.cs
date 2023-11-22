using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuiscChangeTrigger : MonoBehaviour
{
    [Header("Area")]
    [SerializeField] private MusicArea area;
    [SerializeField] private string playerTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            AudioManager.instance.SetMusicArea(area);
        }
    }


}