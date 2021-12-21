using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{

    

    public GameObject[] destination;
    UnityEngine.AI.NavMeshAgent agent;
    public IEnumerator ComputePath() 
    {
        destination = GameObject.FindGameObjectsWithTag("Arrivé");
        float minDistance = Mathf.Infinity;
        int minTarget = 0;
        List<NavMeshPath> SelectedPath = new List<NavMeshPath>();
        agent.isStopped = true;
        for(int i = 0; i < destination.Length; i++) 
        {
            UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
            //agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (agent.CalculatePath(destination[i].transform.position, path))
            {

                while (agent.pathPending)
                {
                    yield return 0;
                }

                if (path.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
                {
                    SelectedPath.Add (path);   
                }
            }
        }
        for(int j = 0; j < SelectedPath.Count; j++)
        {
            agent.SetPath(SelectedPath[j]);
            Debug.Log(agent.remainingDistance);
            if (agent.remainingDistance < minDistance)
            {
                minTarget = j;
                minDistance = agent.remainingDistance;
            }
        }
        Debug.Log(minTarget);
        agent.destination = destination[minTarget].transform.position;
        agent.isStopped = false;
    }

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
               
    }


    ////public Transform goal;
    //GameObject[] targets;
    //private int i = 0;
    //public UnityEngine.AI.NavMeshAgent agent;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    //    //agent.destination = goal.position;
    //    //agent.SetDestination(GameObject.FindGameObjectWithTag("Arrivé").transform.position);
    //    targets = GameObject.FindGameObjectsWithTag("Arrivé");
    //    agent.destination = targets[i].transform.position;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    var dist = Vector3.Distance(targets[i].transform.position, transform.position);

    //    Debug.Log(dist);

    //    for (i = 0; i < targets.Length; i++)
    //    {
    //        if (dist < Vector3.Distance(targets[0].transform.position, transform.position))
    //        {
    //            agent.destination = targets[i].transform.position;
    //        }
    //        else
    //        {
    //            i++;
    //        }
    //    }

    //currentTarget = targets[i].transform;
    //if npc reaches its destination (or gets close)...
    //if (dist < 2)
    //{
    //    for (i = 0; i <= targets.Length; i++)
    //    {


    //        //i++; //change next target      
    //        if (i < targets.Length)
    //        {
    //            agent.destination = targets[i].transform.position; //go to next target by setting it as the new destination
    //        }
    //    }
    //    //check if at end of cycle, then reset to beginning of cycle
    //    //if (i == targets.Length)
    //    //{
    //    //    Debug.Log("NAVIGATION FINISHED. RESET.");
    //    //    i = 0;
    //    //    agent.destination = targets[i].transform.position;
    //    //}
    //}
    //}
    //public Transform goal;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    //    agent.destination = goal.position;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
