using System.Collections;
using System.Collections.Generic;


/* public class RaycastAgent : MonoBehaviour{

    private void Update()


    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        if (Physics.SphereCast(transform.position, transform.lossyScale.x / 2 ,transform.right, out hit, 10))
        {
            Debug.Log("touch");
        }
    }

}*/

using UnityEngine;

public class RaycastAgent : MonoBehaviour
{
    public float maxDistance = 10f;
    private bool isHit;
    private RaycastHit hit;
    public double rand_nbr;
    public double seuil = 65;
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rand_nbr = Random.Range(0, 100);
    }
    public void set_alerte()
    {
        rend.material.color = Color.red;
        transform.gameObject.tag = "Alerte";
        this.GetComponent<agent>().enabled = true;
    }

    void Update()
    {
        

        isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, transform.forward, out hit, maxDistance);
        if (isHit)
        {


            if (hit.collider.CompareTag("Alerte") && rend.material.color != Color.red)
            {
                if (rand_nbr >= seuil)
                {
                    set_alerte();
                }
                else
                {
                    rand_nbr = rand_nbr * 1.05;
                }
                /*this.GetComponent<Boids>().enabled = true;
                this.GetComponent<Cohesion>().enabled = true;*/
            }
        }

    }
    void OnDrawGizmos()
    {
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, transform.lossyScale.x / 2);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }
}
