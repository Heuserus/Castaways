using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // The time, in seconds, after which the bullet should be deleted
    public float lifetime = 3f;

    // The time at which the bullet was created
    private float creationTime;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        // Record the time at which the bullet was created
        creationTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the lifetime of the bullet has expired
        if (Time.time - creationTime > lifetime)
        {
            // Destroy the bullet GameObject
            Destroy(gameObject);
        }
    }
}

