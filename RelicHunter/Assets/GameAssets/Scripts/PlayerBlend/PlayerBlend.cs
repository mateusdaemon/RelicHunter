using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlend : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerOrient playerOrient;
    private PlayerState playerState;
    private PlayerRun playerRun;
    private PlayerSlow playerSlow;
    private PlayerTakeRune playerTakeRune;
    private PlayerAnimBlend playerAnimBlend;
    private PlayerMove playerMove;
    private PlayerJump playerJump;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerOrient = GetComponent<PlayerOrient>();
        playerState = GetComponent<PlayerState>();
        playerRun = GetComponent<PlayerRun>();
        playerSlow = GetComponent<PlayerSlow>();
        playerTakeRune = GetComponent<PlayerTakeRune>();
        playerAnimBlend = GetComponent<PlayerAnimBlend>();
        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();
        

        playerState.OnStateChange += playerAnimBlend.SetAnim;
    }

    private void Start()
    {
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