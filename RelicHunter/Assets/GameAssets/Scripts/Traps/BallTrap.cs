using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrap : MonoBehaviour, ITrap
{
    [SerializeField] private float damage;
    private GameObject playerRef;

    public void Activate()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRef = collision.gameObject;
            playerRef.GetComponent<ITakeDamage>().TakeDamage(damage);
        }
    }
}
