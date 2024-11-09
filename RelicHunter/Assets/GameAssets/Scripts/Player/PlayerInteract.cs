using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    PlayerInput playerInput;
    bool justInteract = false;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (playerInput.InteractInput && !justInteract)
        {
            IInteract interaction = other.gameObject.GetComponent<IInteract>();

            if (interaction != null) 
            {
                justInteract = true;
                interaction.Interact();
                Invoke("CanInteract", 1f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteract interaction = other.gameObject.GetComponent<IInteract>();

        if (interaction != null)
        {
            HudManager.Instance.SetInteractPop(true);
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

    private void CanInteract()
    {
        justInteract = false;
    }
}
