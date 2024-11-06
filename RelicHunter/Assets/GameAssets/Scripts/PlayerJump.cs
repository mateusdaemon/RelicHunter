using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer; // Define the ground layer in the inspector
    [SerializeField] private float groundCheckDistance = 0.1f; // Adjust as needed for accurate ground detection

    private Rigidbody rb;
    private PlayerState playerState;
    private RaycastHit hit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerState.ChangeState(State.Jump);
            
        } else
        {
            Debug.Log("im not grounded");
        }
    }

    private bool IsGrounded()
    {
        return Physics.SphereCast(transform.position, transform.localScale.x / 2, -Vector3.up, out hit, groundCheckDistance);
    }

    private void OnDrawGizmos()
    {
        bool isGrounded = Physics.SphereCast(transform.position, transform.localScale.x / 2 * 3, -Vector3.up, out hit, groundCheckDistance);

        if (isGrounded)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, -Vector3.up * groundCheckDistance);
            Gizmos.DrawWireSphere(transform.position + (-Vector3.up * hit.distance), transform.localScale.x / 2);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, -(Vector3.up * groundCheckDistance + (Vector3.up * transform.localScale.x / 2)));
        }
    }
}
