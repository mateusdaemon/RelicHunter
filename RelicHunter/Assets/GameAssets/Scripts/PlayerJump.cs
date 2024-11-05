using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer; // Define the ground layer in the inspector
    [SerializeField] private float groundCheckDistance = 0.1f; // Adjust as needed for accurate ground detection

    private Rigidbody rb;
    private Vector3 rayStart;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rayStart = transform.position;
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            Debug.Log("Is groundddd");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        // Set the color for the gizmo
        Gizmos.color = Color.red;

        // Draw the ray from the player's position downwards
        Vector3 origin = transform.position;
        Vector3 direction = Vector3.down * groundCheckDistance;
        Gizmos.DrawLine(origin, origin + direction);
    }
}
