using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimBlend : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnim(State state)
    {
        animator.SetBool("crouch", false);

        switch (state)
        {
            case State.Walk:
                animator.SetFloat("speed", 5f);
                break;
            case State.Idle:
                animator.SetFloat("speed", 0f);
                break;
            case State.Run:
                animator.SetFloat("speed", 7f);
                break;
            case State.Crouch:
                animator.SetBool("crouch", true);
                animator.SetFloat("speed", 0f);
                break;
            case State.CrouchWalk:
                animator.SetBool("crouch", true);
                animator.SetFloat("speed", 1f);
                break;
            case State.Jump:
                animator.SetTrigger("jump");
                break;
            case State.SlowWalk:
                animator.SetFloat("speed", 1f);
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
