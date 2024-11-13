using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornTrap : MonoBehaviour, ITrap
{
    [SerializeField] private float damage;
    private GameObject playerRef;

    public void Activate()
    {
        if (playerRef != null)
        {
            playerRef.GetComponent<ITakeDamage>().TakeDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRef = other.gameObject;
            Activate();
        }
    }
}
