using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    private Vector3 target;
    public Transform[] waypoints;
    private int WayPointsIndex = 0;

    public float speed;
    [SerializeField] private float StopTime;
    [SerializeField]private float currentTime;
    private void Start()
    {
        UpdateDestination();
      
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position,target) > 0.2f)
        {
            //move to target
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.LookAt(target);
        }
        else
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
        target = waypoints[WayPointsIndex].position;
       
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
