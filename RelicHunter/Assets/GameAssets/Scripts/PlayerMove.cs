using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float BaseSpeed { get; private set; } = 5f;
    public float MoveSpeed { get; set; }

    private Rigidbody rb;
    private PlayerState playerState;
    private PlayerInput playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void Move(Vector3 direction, bool crouch, bool run, bool slowWalk)
    {
        if (direction.magnitude > 0)
        {
            Vector3 camForward = Camera.main.transform.forward;
            Vector3 camRight = Camera.main.transform.right;
            camForward.y = 0;
            camForward.Normalize();

            direction = camForward * direction.z + camRight * direction.x;
            direction.Normalize();

            Vector3 horizontalVelocity = direction * MoveSpeed;

            if (run)
            {
                playerState.ChangeState(State.Run);
            } else if (crouch)
            {
                playerState.ChangeState(State.CrouchWalk);
            } else if (slowWalk)
            {
                playerState.ChangeState(State.SlowWalk);

            } else
            {
                playerState.ChangeState(State.Walk);
            }

            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);

            if (crouch)
            {
                playerState.ChangeState(State.Crouch);
            } else
            {

                playerState.ChangeState(State.Idle);
            }
        }
    }
}
