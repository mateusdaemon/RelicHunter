using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    private ZombieDetectPlayer detectPlayer; // Reference to player detection component
    private Pursue pursueScript; // Reference to the Pursue3D script
    private Patrol patrolScript; // Reference to the Patrol3D script

    private void Awake()
    {
        detectPlayer = GetComponent<ZombieDetectPlayer>();
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
        if (detectPlayer.IsPlayerInRange)
        {
            // If the player is in range, pursue the player
            pursueScript.enabled = true;
            patrolScript.enabled = false;
        }
        else
        {
            // Otherwise, continue patrolling
            pursueScript.enabled = false;
            patrolScript.enabled = true;
        }
    }
}
