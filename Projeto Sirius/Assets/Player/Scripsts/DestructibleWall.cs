using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    [SerializeField] private Rigidbody[] WallParts;
    [SerializeField] private float force=1;
    [HideInInspector]public bool DoOnce = false;
    [SerializeField] private DestructibleWallTrigger Trigger;

    public void BreakWall()
    {
        for(int i = 0; i< WallParts.Length; i++)
        {
            WallParts[i].isKinematic = false;
            WallParts[i].velocity = new Vector3(force, 0f, 0f);

        }
        DoOnce = true;

        Destroy(this,5f);
    }
}
