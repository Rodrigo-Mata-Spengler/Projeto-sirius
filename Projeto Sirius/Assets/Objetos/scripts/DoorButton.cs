using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{

    [SerializeField] private Door[] Door;

    public void OpenDoor(Transform Player)
    {
        for (int i = 0; i < Door.Length; i++)
        {
            if (!Door[i].IsOpen)
            {
                Door[i].Open(Player.transform.position);

            }
        }
    }
}
