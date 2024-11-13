using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActivateBtn : MonoBehaviour
{
    [SerializeField] private BallTrap ballTrap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ballTrap.Activate();
        }
    }
}
