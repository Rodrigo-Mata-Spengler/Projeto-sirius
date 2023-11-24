using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;

public class DestructibleWall : MonoBehaviour
{
    [SerializeField] private Rigidbody[] WallParts;
    [SerializeField] private float force=1;
    [HideInInspector]public bool DoOnce = false;
    [SerializeField] private DestructibleWallTrigger Trigger;
    [SerializeField] private float destructionTime = .5f;

    [Header("Sons")]
    [SerializeField] private StudioEventEmitter wallDestrution_Sound;

    public void BreakWall()
    {
        for(int i = 0; i< WallParts.Length; i++)
        {
            WallParts[i].isKinematic = false;
            WallParts[i].velocity = new Vector3(force, 0f, 0f);
            Destroy(WallParts[i].gameObject, destructionTime);

        }

        if (!wallDestrution_Sound.IsPlaying())
        {
            wallDestrution_Sound.Play();
        }

        DoOnce = true;

        
    }
}
