using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour, ITrap
{
    [SerializeField] private float damage;
    private GameObject playerRef;
    private TrapAnim trapAnim;
    private bool isActive = true;

    private void Awake()
    {
        trapAnim = GetComponent<TrapAnim>();
    }

    public void Activate()
    {
        if (isActive)
        {
            trapAnim.SetAnim(TrapState.Active);
            isActive = false;
            Invoke("ActiveTrap", 2f);
            if (playerRef != null)
            {
                playerRef.GetComponent<ITakeDamage>().TakeDamage(damage);
            }
        }
    }

    private void ActiveTrap()
    {
        isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRef = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRef = null;
        }
    }
}
