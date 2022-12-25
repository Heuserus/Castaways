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
    private float angle;

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is clicked
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
               

                // Instantiate the bullet at the position of the cannon
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                //calculate Angle bet
                angle = AngleBetween(AngleToVector(player.transform.rotation.y).normalized,(target - transform.position).normalized);
                Debug.Log(angle);
                // Add force to the bullet in the direction of the target
                bullet.GetComponent<Rigidbody>().AddForce(((target - transform.position).normalized + new Vector3 (0f, upForce, 0f)) * firingForce);
                
            }
        }
    }

    public static Vector3 AngleToVector(float angle)
{
    // Convert the angle to radians
    float radians = angle * Mathf.Deg2Rad;

    // Calculate the x and z components of the vector using trigonometry
    float x = Mathf.Cos(radians);
    float z = Mathf.Sin(radians);

    // Return the vector with a y component of 0
    return new Vector3(x, 0f, z);
}


    private float AngleBetween(Vector3 v1, Vector3 v2)
        {
            // Normalize the input vectors
            v1.Normalize();
            v2.Normalize();

            // Calculate the dot product of the vectors
            float dot = Vector3.Dot(v1, v2);

            // Clamp the dot product to the [-1, 1] range to prevent errors when calculating the arc cosine
            dot = Mathf.Clamp(dot, -1f, 1f);

            // Calculate the angle between the vectors in radians
            float angle = Mathf.Acos(dot);

            // Convert the angle to degrees
            angle = angle * Mathf.Rad2Deg;

            return angle;
        }

}
