using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour, ITakeDamage
{
    private PlayerFx playerFx;
    private void Awake()
    {
        playerFx = GetComponent<PlayerFx>();
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
        GameManager.Instance.PlayerDied();
    }
}
