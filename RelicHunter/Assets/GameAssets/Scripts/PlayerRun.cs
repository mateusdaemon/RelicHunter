using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [SerializeField] private float runSpeedMultiplier = 1.5f;
    private PlayerMove playerMove;
    private PlayerState playerState;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
        playerState = GetComponent<PlayerState>();
    }

    public void Run(bool isRunning)
    {
        if (isRunning)
        {
            playerMove.MoveSpeed = playerMove.BaseSpeed * runSpeedMultiplier;
            playerState.ChangeState(State.Run);
        }        
    }
}
