using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrient : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField]private float orientationSpeed = 60;
    private void Awake()
    {
        playerTransform = transform;
    }
    public void Orient(Vector3 direction)
    {
        if (direction.magnitude > 0)
        {
            Vector3 camForward = Camera.main.transform.forward;
            Vector3 camRight = Camera.main.transform.right;

            camForward.y = 0;
            camForward.Normalize();

            direction = camForward * direction.z + camRight * direction.x;
            direction.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, Time.deltaTime * orientationSpeed);
        }
    }
}
