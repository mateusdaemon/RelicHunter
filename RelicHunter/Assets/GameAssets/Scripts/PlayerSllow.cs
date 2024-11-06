using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSllow : MonoBehaviour
{
    [SerializeField] private float slowSpeedMultiplier = 0.5f;
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
