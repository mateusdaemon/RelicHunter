using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer; // Layer assigned to ground
    [SerializeField] private Transform groundCheck; // Empty object at the feet of the player
    [SerializeField] private float groundCheckRadius = 0.3f; // Radius of the ground check sphere

    private Rigidbody rb;
    private PlayerState playerState;
    private bool isGrounded;

    public float fallMultiplier;
    public float lowJumpMultiplier;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        CheckGroundStatus();
    }

    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            HandleFalling();
        }
    }

    private void HandleFalling()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * (-fallMultiplier);
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector3.up * (-lowJumpMultiplier);
        }

    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerState.ChangeState(State.Jump);
            isGrounded = false; // Prevents immediate re-jumping
        }
        else
        {
            Debug.Log("Player is not grounded, cannot jump.");
        }
    }

    private void CheckGroundStatus()
    {
        // Detect if the player is touching the ground using CheckSphere
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
