using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMove playerMove;
    private PlayerJump playerJump;
    private PlayerOrient playerOrient;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();
        playerOrient = GetComponent<PlayerOrient>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.JumpInput)
        {
            playerJump.Jump();
        }
    }

    private void FixedUpdate()
    {
        playerMove.Move(playerInput.MoveInputDirection);
        playerOrient.Orient(playerInput.MoveInputDirection);
    }
}
