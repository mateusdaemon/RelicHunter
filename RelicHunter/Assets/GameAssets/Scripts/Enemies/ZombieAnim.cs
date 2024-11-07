using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnim(State state)
    {
        switch (state)
        {
            case State.Attack:
                animator.SetTrigger("attack");
                break;
            case State.None:
                break;
        }
    }
}
