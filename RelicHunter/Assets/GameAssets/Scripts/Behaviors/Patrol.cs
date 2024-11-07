using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject[] arrPaths; // Array of waypoints
    private int index = 0;

    private Vector3 targetPosition;

    private Vector3 direction;
    private Vector3 velocity;

    public float speed = 5f;

    private Vector3 desiredVelocity;
    private Vector3 steeringVelocity;
    public float mass = 10f;

    private void Start()
    {
        if (arrPaths.Length > 0)
        {
            targetPosition = arrPaths[0].transform.position;
        }

        InvokeRepeating("ChangePoint", 0, 3f); // Change patrol point every 3 seconds
    }

    private void Update()
    {
        if (arrPaths.Length == 0) return; // Exit if no waypoints

        targetPosition.y = transform.position.y;

        // Calculate the direction and desired velocity towards the target point
        direction = (targetPosition - transform.position).normalized;
        desiredVelocity = direction * speed;

        // Calculate steering velocity
        steeringVelocity = (desiredVelocity - velocity) / mass;

        // Update velocity
        velocity += steeringVelocity * Time.deltaTime;

        // Move towards the target if we're not close enough
        if (Vector3.Distance(targetPosition, transform.position) > 0.5f)
        {
            transform.position += velocity * Time.deltaTime;
        }

        // Rotate to face the direction of movement
        if (velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }
    }

    private void ChangePoint()
    {
        // Increment index to move to the next waypoint, looping back to the start if necessary
        index = (index + 1) % arrPaths.Length;
        targetPosition = arrPaths[index].transform.position;
    }
}
