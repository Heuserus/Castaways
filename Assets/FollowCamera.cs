using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // The target to follow
    public Transform target;

    // The distance in the x-z plane to the target
    public float distance = 10.0f;

    // The height we want the camera to be above the target
    public float height = 5.0f;

    // How much we  want to dampen the camera's movement
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    // Use this for initialization
    void Start()
    {
        // Ensure the camera is positioned correctly at the start
        LateUpdate();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Early out if we don't have a target
        if (!target)
            return;
     
        transform.position = target.position + new Vector3(0f,height,0f);
        

    }
}

