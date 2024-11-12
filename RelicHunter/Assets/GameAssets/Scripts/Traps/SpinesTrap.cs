using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinesTrap : MonoBehaviour, ITrap
{
    [SerializeField] private float damage;
    private GameObject playerRef;
    private TrapAnim trapAnim;
    private bool trapActive = true;

    private void Awake()
    {
        trapAnim = GetComponent<TrapAnim>();
    }

    public void Activate()
    {
        if (playerRef != null)
        {
            trapAnim.SetAnim(TrapState.Active);
            playerRef.GetComponent<ITakeDamage>().TakeDamage(damage);
        }
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

    private void OnTriggerStay(Collider other)
    {
        if (trapActive)
        {
            if (playerRef != null)
            {
                PlayerState state = playerRef.GetComponent<PlayerState>();
                if (state.State != State.SlowWalk)
                {
                    Activate();
                    trapActive = false;
                    Invoke("TrapActive", 2f);
                }
            }
        }
    }

    private void TrapActive()
    {
        trapActive = true;
    }
}
