using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > minimumDistance){
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);      
        }else{
            

        }
    }
}
