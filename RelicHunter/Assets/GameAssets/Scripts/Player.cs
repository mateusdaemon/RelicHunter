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

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();
        playerOrient = GetComponent<PlayerOrient>();
        playerAnim = GetComponent<PlayerAnim>();
        playerState = GetComponent<PlayerState>();
        playerRun = GetComponent<PlayerRun>();

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
    }

    private void FixedUpdate()
    {
        playerMove.Move(playerInput.MoveInputDirection, playerInput.CrouchInput, playerInput.RunInput);
        playerOrient.Orient(playerInput.MoveInputDirection);
    }
}
