using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfview : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask PlayerMask;
    public LayerMask AmbienteMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    //[HideInInspector]
    public bool SeePlayer;

    [SerializeField] private EnemyPatrol enemyPatrolScript;

    private void Start()
    {
        StartCoroutine(FindTargetsWithDelay(.2f));

    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTrgets();
        }
    }
    void FindVisibleTrgets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, PlayerMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, AmbienteMask))
                {

                    visibleTargets.Add(target);
                    SeePlayer = true;
                    Debug.LogWarning("vi");

                    enemyPatrolScript.target = target.position;
                }
                else
                {
                    SeePlayer = false;
                }

            }
        }
    }

    public Vector3 DirFromAngle(float AngleInDegrees, bool AngleIsGlobal)
    {
        if (!AngleIsGlobal)
        {
            AngleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(AngleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(AngleInDegrees * Mathf.Deg2Rad));
    }
}