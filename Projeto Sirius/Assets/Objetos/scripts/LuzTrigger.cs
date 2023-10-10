using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTrigger : MonoBehaviour
{
    [SerializeField] private  LightOff lightOffScript;

    public void LightOn()
    {
        if (!lightOffScript.off)
        {
            lightOffScript.LightsOff();
        }
        else
        {
            lightOffScript.LightOn();
        }
    }
}
