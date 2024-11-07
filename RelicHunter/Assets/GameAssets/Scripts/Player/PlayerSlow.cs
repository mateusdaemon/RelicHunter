using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlow : MonoBehaviour
{
    [SerializeField] private float slowSpeedMultiplier = 0.1f;
    private PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    public void Slow(bool isSlowing)
    {
        if (isSlowing)
        {
            playerMove.MoveSpeed = playerMove.BaseSpeed * slowSpeedMultiplier;
        }
    }
}
