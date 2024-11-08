using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject door;
    [SerializeField] private int runesToOpen;
    private bool doorOpened = false;

    private void Awake()
    {
        
    }

    public void Interact()
    {
        if (doorOpened) return;
        
        if (GameManager.Instance.Inventory.runesCollected < runesToOpen)
        {
            HudManager.Instance.SetCantOpenDoor(door);
        }

        if (GameManager.Instance.Inventory.runesCollected >= runesToOpen)
        {
            Animator doorAnim = door.GetComponent<Animator>();
            doorAnim.SetTrigger("open");
            doorOpened = true;
            Invoke("CloseDoor", 8f);
        }
    }

    private void CloseDoor()
    {
        doorOpened = false;
        Debug.Log("Door closed");
    }
}
