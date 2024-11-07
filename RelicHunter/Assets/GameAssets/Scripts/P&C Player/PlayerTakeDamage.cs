using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour, ITakeDamage
{
    public void TakeDamage(float damage)
    {
        Debug.Log("Hit me with " + damage + " of damage");
    }
}
