using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer rend;
    public int rand_nbr;
    private RaycastAgent[] gene;
    public GameObject Agent;

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
                float x = Random.Range(-5,5);
                float y= Random.Range(-5,5);
                Instantiate(Agent, new Vector3(x,0,y), Quaternion.Euler(0,Random.Range(0,90),0));
            }
        }
    }
}
