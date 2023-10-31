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
            Debug.Log(hit.transform.tag.ToString());
            if (hit.transform.CompareTag(tagPlayer) || hit.transform.CompareTag(tagPontoDeInteresse))
            {
                controler.NewPointOfInterest(other.transform.position);
            }
        }    
    }
}
