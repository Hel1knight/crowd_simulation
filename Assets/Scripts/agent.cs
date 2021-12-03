using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    //public Transform goal;
    GameObject[] targets;
    private int i = 0;
    public UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //agent.destination = goal.position;
        //agent.SetDestination(GameObject.FindGameObjectWithTag("Arrivé").transform.position);
        targets = GameObject.FindGameObjectsWithTag("Arrivé");
        agent.destination = targets[i].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(targets[i].transform.position, transform.position);
        //currentTarget = targets[i].transform;
        //if npc reaches its destination (or gets close)...
        if (dist < 2)
        {
            i++; //change next target      
            if (i < targets.Length)
            {
                agent.destination = targets[i].transform.position; //go to next target by setting it as the new destination
            }
            
            //check if at end of cycle, then reset to beginning of cycle
            if (i == targets.Length)
            {
                Debug.Log("NAVIGATION FINISHED. RESET.");
                i = 0;
                agent.destination = targets[i].transform.position;
            }
        }
    }
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
