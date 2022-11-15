using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{
    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;
    bool once;

    public NavMeshAgent agent;

    // Update is called once per frame
    private void Update()
    {    
        if (transform.position.x != patrolPoints[currentPointIndex].position.x && transform.position.z != patrolPoints[currentPointIndex].position.z){
            // transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
            agent.SetDestination(patrolPoints[currentPointIndex].position);
            
        }else{
            if (once == false){
                once = true;
                StartCoroutine(Wait());
            }
            
        }
        
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length){
            currentPointIndex++;
            
        }else{
            currentPointIndex = 0;
        }
        once = false;
    }

}
