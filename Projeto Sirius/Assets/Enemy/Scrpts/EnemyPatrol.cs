using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [HideInInspector]public Vector3 target;
    public Transform[] waypoints;
    private int WayPointsIndex = 0;

    public float speed;
    [SerializeField] private float StopTime;
    [SerializeField]private float currentTime;

    [HideInInspector] public bool seePlayer = false;
    private GameObject Player;
    private void Start()
    {
        UpdateDestination();
        Player = GameObject.FindGameObjectWithTag("Player");
      
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, target) > 0.2f && seePlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.LookAt(target);
        }
        if(Vector3.Distance(transform.position,target) > 0.2f && !seePlayer)
        {
            //move to target
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.LookAt(target);
        }
        else if(!seePlayer)
        {
            Delay();
        }
    }

    void Delay()
    {
        currentTime += Time.deltaTime;

        if(currentTime < StopTime)
        {

        }
        else
        {
            IterateWaypointIndex();
            UpdateDestination();
            currentTime = 0;
        }

    }

    void UpdateDestination()
    {
        if (seePlayer)
        {
            target = Player.transform.position;
        }
        else
        {
            target = waypoints[WayPointsIndex].position;
        }
        
       
    }
    void IterateWaypointIndex()
    {
        WayPointsIndex++;
        if(WayPointsIndex == waypoints.Length)
        {
            WayPointsIndex = 0;
        }
    }
}
