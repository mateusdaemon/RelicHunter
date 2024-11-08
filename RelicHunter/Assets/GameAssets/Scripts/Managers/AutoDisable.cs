using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    [SerializeField] private float timeAlive;

    private void OnEnable()
    {
        Invoke("DisableMe", timeAlive);
    }

    private void DisableMe()
    {
        gameObject.SetActive(false);
    }
}
