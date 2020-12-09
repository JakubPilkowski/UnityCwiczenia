using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FieldOfView : MonoBehaviour
{

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask playerMask;
    public LayerMask obstacleMask;

    [Header("Events")]
    [Space]
    public UnityEvent OnDetectPlayer;
    public UnityEvent OnLosePlayer;

    public Transform player;

    void Start()
    {
        StartCoroutine(FindTargetsWithDelay(.2f));
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds (delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        player = null;
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, playerMask);
        
        for(int i=0; i < targetsInViewRadius.Length; i++) {
            Transform target = targetsInViewRadius[0].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.right, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    OnDetectPlayer.Invoke();
                    player = target;
                    Debug.Log("Jest Player");
                }
                else
                {
                    OnLosePlayer.Invoke();
                }
            }
            else
            {
                OnLosePlayer.Invoke();
            }
        }
        if(targetsInViewRadius.Length == 0)
        {
            OnLosePlayer.Invoke();
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), -Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }
}
