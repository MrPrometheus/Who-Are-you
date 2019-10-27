using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpsAIPatrolPoints : MonoBehaviour
{
    public float speed = 2;
    public List<Transform> patrolPoints= new List<Transform>();
    
    private Transform currentPatrolPoint;
    private int currentPatrolIndex;
    private Animator animator;

    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f)
        {
            if (currentPatrolIndex + 1 < patrolPoints.Count) currentPatrolIndex++;
            else currentPatrolIndex = 0;
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }

        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f;
        
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);
    }
}
