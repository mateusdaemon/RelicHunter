using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeArrowTrap : MonoBehaviour
{
    [SerializeField] private ArrowTrap arrowTrap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            arrowTrap.Activate();
        }
    }
}
