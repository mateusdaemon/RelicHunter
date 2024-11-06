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
    private PlayerSlow playerSlow;
    private PlayerTakeRune playerTakeRune;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();
        playerOrient = GetComponent<PlayerOrient>();
        playerAnim = GetComponent<PlayerAnim>();
        playerState = GetComponent<PlayerState>();
        playerRun = GetComponent<PlayerRun>();
        playerSlow = GetComponent<PlayerSlow>();
        playerTakeRune = GetComponent<PlayerTakeRune>();

        playerState.OnStateChange += playerAnim.SetAnim;

        Rune activeRune = GameManager.Instance.Inventory.GetActiveRune();
        if (activeRune != Rune.None)
        {
            playerTakeRune.TakeRune(activeRune);
        }
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
