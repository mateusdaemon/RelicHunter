using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrapState
{
    Idle,
    Active,
    None
}

public class TrapAnim : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnim(TrapState state)
    {
        switch (state)
        {
            case TrapState.Active:
                animator.SetTrigger("active");
                break;
            case TrapState.Idle:
                break;
            case TrapState.None:
                break;
        }
    }
}
