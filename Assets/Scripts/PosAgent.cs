using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosAgent : MonoBehaviour
{
    public bool Started = false;
    public GameObject[] agent;
    public int[][] Pos = new int[10][];
    public float lerpValue;
    public double Case = 1;
    public void ListAgent()
    {
        agent = GameObject.FindGameObjectsWithTag("Alerte");
    }

    public void Stats()
    {
        for (int i = 0; i < Pos.Length; i++)
        {
            Pos[i] = new int[10];
        }
        for (int i = 0; i < agent.Length; i++) //passage dans le tableau d'agent
        {
            for (int x = 0; x < Pos.Length; x++) //tableau de position coordonnées x
            {
                for (int z = 0; z < Pos[x].Length; z++) //tableau de position coordonnées z
                {
                    if (agent[i].transform.position.x >= Case * x)
                    {
                        if (agent[i].transform.position.x < Case * x + Case)
                        {
                            if (agent[i].transform.position.z >= Case * z)
                            {
                                if (agent[i].transform.position.z < Case * z + Case)
                                {
                                    Pos[x][z] += 1;
                                    Debug.Log(Pos[x][z]);
                                }
                            }
                        }
                    }
                }
            }
        }
        Started = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ListAgent();
        Stats();
    }
}
