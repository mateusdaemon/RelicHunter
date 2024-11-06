using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Walk,
    Idle,
    Run,
    Hit,
    Death,
    Crouch,
    CrouchWalk,
    Jump,
    None
}

public class PlayerState : MonoBehaviour
{
    public State State { get; private set; }
    public event Action<State> OnStateChange;

    private void Start()
    {
        State = State.None;
    }

    public void ChangeState(State newState)
    {
        switch (newState)
        {
            case State.Walk:
                State = State.Walk;
                break;
            case State.Run:
                State = State.Run;
                break;
            case State.Idle:
                State = State.Idle;
                break;
            case State.Crouch:
                State = State.Crouch;
                break;
            case State.CrouchWalk:
                State = State.CrouchWalk;
                break;
            case State.Hit:
                State = State.Hit;
                break;
            case State.Death:
                State = State.Death;
                break;
            case State.None:
                State = State.None;
                break;
        }

        OnStateChange?.Invoke(State);
    }
}
