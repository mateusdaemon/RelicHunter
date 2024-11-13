using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour, ITakeDamage
{
    private PlayerFx playerFx;
    private PlayerState playerState;
    private void Awake()
    {
        playerFx = GetComponent<PlayerFx>();
        playerState = GetComponent<PlayerState>();
    }

    public void TakeDamage(float damage)
    {
        GameManager.Instance.PlayerTakeDamage(damage);
        playerFx.BloodShow();

        if (GameManager.Instance.PlayerData.currentLife <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        playerState.ChangeState(State.Death);
        GameManager.Instance.PlayerDied();
    }
}
