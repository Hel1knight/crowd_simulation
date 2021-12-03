using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.AI; 

public class WaypointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f;
    private float lastWaypointIndex;

    private float movementSpeed = 5.0f;
    private float rotationSpeed = 2.0f;
    private NavMeshAgent agent = null;
    
    // Start is called before the first frame update
    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1; 
        targetWaypoint = waypoints[targetWaypointIndex];
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);//rotationToTarget;

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        
        CheckDistanceToWaypoint(distance);

        agent.destination = targetWaypoint.position;
        //transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
        //Vector3.Lerp(Depart, arrivée, valeur entre 0 et 1);
        
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if(currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoints[targetWaypointIndex];
    }
}
