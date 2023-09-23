using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOff : MonoBehaviour
{
    [SerializeField] private Light[] lights;
    [HideInInspector] public bool off = false;

    public void LightsOff()
    {
        for(int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = false;
        }
    }
    public void LightOn()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = true;
        }
    }
}
