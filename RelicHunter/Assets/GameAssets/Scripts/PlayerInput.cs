using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 MoveInputDirection { get; private set; }
    public bool JumpInput { get; private set; }

    private void Update()
    {
        // Capture horizontal and vertical input (for 3D movement)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Set the input direction as a normalized vector
        MoveInputDirection = new Vector3(horizontal, 0, vertical).normalized;

        JumpInput = Input.GetKeyDown(KeyCode.Space);
    }
}
