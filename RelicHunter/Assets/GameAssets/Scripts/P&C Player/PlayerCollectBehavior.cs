using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectBehavior : MonoBehaviour
{
    [SerializeField] private AudioClip collect;
    [SerializeField] private AudioSource playerSounds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            playerSounds.clip = collect;
            playerSounds.Play();
            other.gameObject.GetComponent<ICollect>().Collect();
        }
    }
}
