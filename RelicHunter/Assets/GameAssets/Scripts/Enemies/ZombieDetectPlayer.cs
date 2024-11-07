using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDetectPlayer : MonoBehaviour
{
    private GameObject player; // Reference to the player GameObject
    [SerializeField]private float detectionRadius = 10f; // Detection radius within which the zombie will detect the player

    public bool IsPlayerInRange {  get; private set; }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDrawGizmosSelected()
    {
        // Draw detection radius in the editor for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    private void Update()
    {
        // Check if the player is within detection range
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        IsPlayerInRange = distanceToPlayer <= detectionRadius;
    }
}
