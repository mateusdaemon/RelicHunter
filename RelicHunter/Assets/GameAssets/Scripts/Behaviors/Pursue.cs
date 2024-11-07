using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MonoBehaviour {

    Rigidbody rb;  // Rigidbody for the zombie
    Rigidbody targetRb;  // Rigidbody for the target (Player)

    private GameObject target;
    Vector3 targetPos;

    Vector3 direction;
    Vector3 velocity = new Vector3(1, 0, 0);

    Vector3 desiredVelocity;
    Vector3 steeringVelocity;

    public float speed = 5f;
    public float mass = 20f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        targetRb = target.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Calculate the predicted future position of the target
        targetPos = GetTargetFuturePosition();

        targetPos.y = transform.position.y;

        // Calculate the desired direction and velocity towards the target
        direction = (targetPos - transform.position).normalized;
        desiredVelocity = direction * speed;

        // Steering velocity to pursue the target
        steeringVelocity = (desiredVelocity - velocity) / mass;

        // Update velocity based on steering
        velocity += steeringVelocity;
    }

    private void FixedUpdate()
    {
        // Apply velocity to the zombie's Rigidbody
        rb.velocity = velocity;

        // Rotate to face the direction of movement
        if (velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * speed);
        }
    }

    Vector3 GetTargetFuturePosition()
    {
        if (targetRb.velocity.magnitude > 0.5f)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            float T = distance / targetRb.velocity.magnitude;

            return target.transform.position + (targetRb.velocity * T);
        }
        else
        {
            return target.transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(targetPos, 0.5f);
    }


}
