using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.GetComponent<ICollect>().Collect();
        }
    }
}
