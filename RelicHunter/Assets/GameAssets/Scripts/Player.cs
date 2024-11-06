using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMove playerMove;
    private PlayerJump playerJump;
    private PlayerOrient playerOrient;
    private PlayerAnim playerAnim;
    private PlayerState playerState;
    private PlayerRun playerRun;
    private PlayerSllow playerSlow;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();
        playerOrient = GetComponent<PlayerOrient>();
        playerAnim = GetComponent<PlayerAnim>();
        playerState = GetComponent<PlayerState>();
        playerRun = GetComponent<PlayerRun>();
        playerSlow = GetComponent<PlayerSllow>();

        playerState.OnStateChange += playerAnim.SetAnim;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.JumpInput)
        {
            playerJump.Jump();
        }

        playerRun.Run(playerInput.RunInput);
        playerSlow.Slow(playerInput.SlowWalkInput);
    }

    private void FixedUpdate()
    {
        playerMove.Move(playerInput.MoveInputDirection, playerInput.CrouchInput, playerInput.RunInput, playerInput.SlowWalkInput);
        playerOrient.Orient(playerInput.MoveInputDirection);
    }
}
