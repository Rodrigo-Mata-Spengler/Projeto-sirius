using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] private string tagPontoDeInteresse;

    [SerializeField] private EnemyControler controler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer) || other.CompareTag(tagPontoDeInteresse))
        {
            controler.NewPointOfInterest(other.transform.position);
        }    
    }
}
