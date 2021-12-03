using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast_cam : MonoBehaviour
{
    public RaycastHit hit;
    public Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        

    }
        // Update is called once per frame
        void Update()
    {


        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            Debug.Log(hit.transform.position.z);
            Debug.Log("hit");


        }

    }
}
