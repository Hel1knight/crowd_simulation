using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPhysic : MonoBehaviour {

    public Vector3 hitPoint;
    public float hitDistance;
    public float maxDistance;
    public bool aimAtCursor = false;
    void Awake()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        //Crée une position à la position de l'objet
        Vector3 origin = transform.position;
        //Crée une direction correspondant au devant de notre projet
        Vector3 direction = transform.forward;
        //Crée une ray à partir de notre position et notre direction
        Ray ray = new Ray(origin, direction);
        //Crée une variable de type RaycastHit qui récupérera les données de collision
        RaycastHit hit;
        //On envoie notre ray à travers la scène sur 10m
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            hitPoint = hit.point;
            hitDistance = hit.distance;
            
            //GameObject hitObject = hit.collider.gameObject;
        }

        //Cas où l'on ne touche pas
        else
        {
            //Calculer le point a maxdistance devant le drone
            hitPoint = transform.position + transform.forward * maxDistance;
            hitDistance = maxDistance;
        }
        if (aimAtCursor)
        {
            LaserAtCursor();
        }
        else
        {
            LaserForward();
        }
    }
 
    void LaserAtCursor()
    {
        //Trouver la position souris(espace écran)
        Vector3 mousPos = Input.mousePosition;
        Debug.Log(mousPos);
        //Envoyer un raycast dans le monde a partir de cette position(espace monde). On obtient un point X.
        RaycastHit camHit;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 cursorWorldPoint = Vector3.zero;
        if (Physics.Raycast(camRay, out camHit))
        {
           cursorWorldPoint  = camHit.point;
        }
        else
        {
            cursorWorldPoint = Vector3.zero;
        }

        Vector3 dronePosition = transform.position;
        float raycastDistance = Vector3.Distance(dronePosition, cursorWorldPoint);
        Vector3 droneRayDirection = (dronePosition = cursorWorldPoint).normalized;
        RaycastHit droneHit;
        //Envoyer un raycast depuis le drone vers X. On obtient le point final. 
        Ray droneRay = new Ray(transform.position, droneRayDirection);
        if(Physics.Raycast(droneRay, out droneHit, raycastDistance))
        {
            hitPoint = droneHit.point;
            hitDistance = droneHit.distance;
        }
        else
        {
            hitPoint = cursorWorldPoint;
            hitDistance = raycastDistance;
        }
    }

    void LaserForward()
    {
        Ray ray = new Ray(transform.position, transform.forward);
    }


}
