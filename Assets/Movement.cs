using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Speed of the player's movement
    public float speed = 5f;

    


    
    public float dragFactor = 0.1f;
    private Vector3 drag;

    private Vector3 velocity = new Vector3(0f,0f,0f);

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a Vector3 object to store the movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput);

        // Normalize the movement direction so that the player moves at a consistent speed
        movementDirection = movementDirection.normalized;
        
        velocity = velocity + (movementDirection*speed-drag)* Time.deltaTime;
        drag = velocity * dragFactor;
        transform.position += velocity * Time.deltaTime;
        transform.LookAt(transform.position + velocity);
        

    }
}


