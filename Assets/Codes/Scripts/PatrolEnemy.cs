using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{
    //Field of view variables
    public float radius;
    [Range(0,360)]
    public float angle;
    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;
    public float speed;
    public Transform target;
    Vector3 targetLastPosition;

    float timer = 0;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;
    bool once;
    public NavMeshAgent agent;


    //State
    private enum State{
        Patrolling,
        Chasing,
    }
    private State _currentState;

    private void Start()
    {
        _currentState = State.Patrolling;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    // Update is called once per frame
    private void Update()
    {    
        timer += Time.deltaTime;
        float seconds = timer%60;
        if (canSeePlayer){
            agent.isStopped = true;
            _currentState = State.Chasing;
        }else{
            // transform.position = Vector3.MoveTowards(transform.position, targetLastPosition, speed * Time.deltaTime);
            agent.isStopped = false;
            if (Time.deltaTime < seconds){
                _currentState = State.Patrolling;
            }
        }

        if (_currentState == State.Patrolling){
            Patrolling();
        }else{
            Chasing();
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

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    private void Chasing()
    {
        //Chasing
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        targetLastPosition = target.position;

        Vector3 targetDirection = target.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void Patrolling()
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

}
