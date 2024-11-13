using System;
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

    private bool runEnable = false;
    private CapsuleCollider playerCollider;

    // Define height and center values for standing and crouching
    private float standingHeight = 8.0f;
    private float crouchHeight = 6.0f;
    private Vector3 standingCenter = new Vector3(0, 4.0f, 0);
    private Vector3 crouchCenter = new Vector3(0, 3f, 0);

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
        playerCollider = GetComponent<CapsuleCollider>();        

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
        if (GameManager.Instance.PlayerData.PlayerDead()) return;

        if (playerInput.JumpInput)
        {
            playerJump.Jump();
        }

        SetPlayerColliderHeight(playerInput.CrouchInput);

        runEnable = playerRun.Run(playerInput.RunInput);
        playerSlow.Slow(playerInput.SlowWalkInput);
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.PlayerData.PlayerDead()) return;

        playerMove.Move(playerInput.MoveInputDirection, playerInput.CrouchInput, runEnable, playerInput.SlowWalkInput);
        playerOrient.Orient(playerInput.MoveInputDirection);
    }

    private void SetPlayerColliderHeight(bool crouchInput)
    {
        if (crouchInput)
        {
            playerCollider.height = crouchHeight;
            playerCollider.center = crouchCenter;
        }
        else
        {
            playerCollider.height = standingHeight;
            playerCollider.center = standingCenter;
        }
    }
}
