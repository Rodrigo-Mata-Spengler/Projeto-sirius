using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] private string tagPontoDeInteresse;

    [SerializeField] private EnemyControler controler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer) || other.CompareTag(tagPontoDeInteresse))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, ( other.transform.position - transform.position), out hit, Mathf.Infinity);

            if (hit.transform.CompareTag(tagPontoDeInteresse))
            {
                SoundBubble point = other.transform.GetComponent<SoundBubble>();

                if (point.soundLevel >= point.correndo)
                {
                    controler.NewPointOfInterest(other.transform.position);
                }
            }

            if (hit.transform.CompareTag(tagPlayer))
            {
                controler.NewPointOfInterest(other.transform.position);
                controler.FoundPlayer(other.gameObject);
            }
        }    
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(tagPlayer) || other.CompareTag(tagPontoDeInteresse))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, (other.transform.position - transform.position), out hit, Mathf.Infinity);

            if (hit.transform.CompareTag(tagPontoDeInteresse))
            {
                controler.NewPointOfInterest(other.transform.position);
            }

            if (hit.transform.CompareTag(tagPlayer))
            {
                controler.NewPointOfInterest(other.transform.position);
                controler.FoundPlayer(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(tagPlayer))
        {
            controler.FoundPlayer(null);
        }
    }
}
