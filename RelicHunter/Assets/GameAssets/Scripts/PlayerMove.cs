using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Rigidbody rb;
    private PlayerState playerState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
    }

    public void Move(Vector3 direction)
    {
        if (direction.magnitude > 0)
        {
            Vector3 camForward = Camera.main.transform.forward;
            Vector3 camRight = Camera.main.transform.right;

            camForward.y = 0;
            camForward.Normalize();
            direction = camForward * direction.z + camRight * direction.x;
            direction.Normalize();

            Vector3 horizontalVelocity = Vector3.zero;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                horizontalVelocity = direction * moveSpeed * 1.6f;
                playerState.ChangeState(State.Run);
            } else
            {
                horizontalVelocity = direction * moveSpeed;
                playerState.ChangeState(State.Walk);
            }

            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            playerState.ChangeState(State.Idle);
        }
    }
}
