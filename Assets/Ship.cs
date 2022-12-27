using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject shipBase;
    public GameObject shipMast;
    public GameObject shipFront;
    public GameObject shipRear;
    public GameObject Captain;
    public GameObject control;


    public List<GameObject> rightCannons;
    public List<GameObject> leftCannons;

    public List<GameObject> crew;

    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            // Create a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Create a plane at the position of the cannon and with a normal facing up (in the positive Y direction)
            Plane groundPlane = new Plane(Vector3.up, transform.position);

            // Declare a variable to store the distance from the ray to the ground plane
            float distance;

            // Check if the ray intersects with the ground plane
            if (groundPlane.Raycast(ray, out distance))
            {
                
                // Calculate the point of intersection
                Vector3 target = ray.GetPoint(distance);

                //calculate Angle bet
                angle = Vector3.SignedAngle(AngleToVector(control.transform.eulerAngles.y).normalized,(target - control.transform.position).normalized,Vector3.up);
                
                if(angle > -150 && angle < -30){
                    foreach(GameObject cannon in leftCannons){
                        cannon.GetComponent<Cannon>().shoot(target);
                    }

                }
                if(angle < 150 && angle > 30){
                    
                    foreach(GameObject cannon in rightCannons){
                        cannon.GetComponent<Cannon>().shoot(target);
                    }

                }
            }
        }
    }

    public static Vector3 AngleToVector(float angle)
{

    
    // Convert the angle to radians
    angle = angle * Mathf.Deg2Rad;
    

    // Calculate the x and z components of the vector using trigonometry
    float z = Mathf.Cos(angle);
    float x = Mathf.Sin(angle);

    // Return the vector with a y component of 0

    return new Vector3(x, 0f, z);
}
}
