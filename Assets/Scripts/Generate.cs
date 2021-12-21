using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Generate : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer rend;
    public int rand_nbr;
    private RaycastAgent[] gene;
    public GameObject Agent;
    public GameObject obstacle;
    public RaycastHit hit;
    public Ray ray;
    public LayerMask FloorMask;
   
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gene = GameObject.FindObjectsOfType<RaycastAgent>();
            rand_nbr = Random.Range(0, gene.Length);
            gene[rand_nbr].set_alerte();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i <= 15; i++)
            {
                float x = Random.Range(-5, 5);
                float y = Random.Range(-5, 5);
                Instantiate(Agent, new Vector3(x, 0, y), Quaternion.Euler(0, Random.Range(0, 90), 0));
            }
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 mouse = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {   
            if (Physics.Raycast(ray, out hit,Mathf.Infinity, FloorMask))
            {
                    //Gets the hit position
                    Vector3 targetLookAt = hit.point;
                    Instantiate(obstacle, new Vector3(targetLookAt.x, (float)(targetLookAt.y+0.05), targetLookAt.z), Quaternion.identity);
            }
            
        }
    }
}
