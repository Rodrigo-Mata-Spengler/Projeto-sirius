using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    public string playertag;

    public float tempoP = 0;
    private float tempo = 0;

    public GameObject caixa;

    private void Start()
    {
        tempo = tempoP + Time.time;
    }

    private void Update()
    {
        if (tempo <= Time.time)
        {
            Destroy(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(playertag))
        {
            caixa.transform.position = transform.position;

            Destroy(this);
        }
    }
}
