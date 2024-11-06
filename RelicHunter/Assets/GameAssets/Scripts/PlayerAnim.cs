using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnim(State state)
    {
        animator.SetBool("walk", false);
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("crouch", false);
        animator.SetBool("crouchWalk", false);

        switch (state)
        {
            case State.Walk:
                animator.SetBool("walk", true);
                break;
            case State.Idle:
                animator.SetBool("idle", true);
                break;
            case State.Run:
                animator.SetBool("run", true);
                break;
            case State.Crouch:
                animator.SetBool("crouch", true);
                break;
            case State.CrouchWalk:
                animator.SetBool("crouchWalk", true);
                break;
            case State.Jump:
                animator.SetTrigger("jump");
                break;
            case State.Hit:
                break;
            case State.Death:
                break;
            case State.None:
                break;
        }
    }
}
