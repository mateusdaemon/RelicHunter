using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    private ZombieDetectPlayer detectPlayer; // Reference to player detection component
    private ZombieAttack zombieAttack;
    private ZombieAnim zombieAnim;
    private Pursue pursueScript; // Reference to the Pursue3D script
    private Patrol patrolScript; // Reference to the Patrol3D script
    private bool isAttacking = false;

    private void Awake()
    {
        detectPlayer = GetComponent<ZombieDetectPlayer>();
        zombieAttack = GetComponent<ZombieAttack>();
        zombieAnim = GetComponent<ZombieAnim>();
        pursueScript = GetComponent<Pursue>();
        patrolScript = GetComponent<Patrol>();
    }

    private void Start()
    {
        // Start with patrolling mode
        pursueScript.enabled = false;
        patrolScript.enabled = true;
    }

    private void Update()
    {
        if (!isAttacking)
        {
            if (detectPlayer.IsPlayerInRange)
            {
                pursueScript.enabled = true;
                patrolScript.enabled = false;
            } else {
                pursueScript.enabled = false;
                patrolScript.enabled = true;
            }

            if (detectPlayer.IsPlayerAttackable)
            {
                zombieAttack.Attack();
                pursueScript.enabled = false;
                patrolScript.enabled = false;
                isAttacking = true;
                Invoke("ResetAttack", 1f);
                zombieAnim.SetAnim(State.Attack);
            }
        }
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }
}
