using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // The prefab for the bullet
    public GameObject bulletPrefab;
    public float upForce;
    public GameObject player;


    // The force with which the bullet is fired
    public float firingForce = 1000f;

    public float damage;
    private float angle;



    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is clicked
        
                
        
        
    }
    public void shoot(Vector3 target){
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                
                // Add force to the bullet in the direction of the target
        bullet.GetComponent<Rigidbody>().AddForce(((target - player.transform.position).normalized + new Vector3 (0f, upForce, 0f)) * firingForce);
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


public float AngleBetween(Vector3 v1, Vector3 v2)
{
    // Normalize the vectors
    v1.Normalize();
    v2.Normalize();

    

    // Get the dot product of the vectors
    float dot = Vector3.Dot(v1, v2);

    // Clamp the dot product to the range [-1, 1]
    dot = Mathf.Clamp(dot, -1f, 1f);

    // Calculate the angle between the two vectors
    float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

    
    return angle;
}

}
