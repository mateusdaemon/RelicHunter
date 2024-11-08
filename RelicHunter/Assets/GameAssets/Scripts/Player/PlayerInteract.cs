using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnTriggerStay(Collider other)
    {
        IInteract interaction = other.gameObject.GetComponent<IInteract>();

        if (interaction != null) 
        {
            HudManager.Instance.SetInteractPop(true);
            if (playerInput.InteractInput)
            {
                interaction.Interact();
            }
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        IInteract interaction = other.gameObject.GetComponent<IInteract>();

        if (interaction != null)
        {
            HudManager.Instance.SetInteractPop(false);
        }
    }
}
