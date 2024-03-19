using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;                              

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickNewPatrolPoints();
    }

    // Update is called once per frame

    private void PickNewPatrolPoints()
    {
         _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void PatrolUpdate()
    {
        if(!_isPlayerNoticed)
        {
             if(_navMeshAgent.remainingDistance == 0) 
       {
            PickNewPatrolPoints();
       }
        }
    }

    private void NoticePlayerUpdate()
    {  
      var direction = player.transform.position - transform.position;

      if (Vector3.Angle(transform.forward,direction) < viewAngle)
      
      {
        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up, direction, out hit))
        {
           if(hit.collider.gameObject == player.gameObject)
           {
               _isPlayerNoticed = true;
           }
        }
      } 
    }

    private void ChaseUpdate()
    {
     if (_isPlayerNoticed)
     {
         _navMeshAgent.destination = player.transform.position;
     }
    }
    

    private void Update()
  {
     PatrolUpdate();
     NoticePlayerUpdate();
     ChaseUpdate();
  }
}
