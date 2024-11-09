using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject door;
    [SerializeField] private int runesToOpen;
    [SerializeField] private AudioSource mechSounds;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip closeSound;
    private bool doorOpened = false;

    public void Interact()
    {
        if (doorOpened) return;
        
        if (GameManager.Instance.Inventory.runesCollected < runesToOpen)
        {
            mechSounds.clip = closeSound;
            mechSounds.Play();
            HudManager.Instance.SetCantOpenDoor(door);
        }

        if (GameManager.Instance.Inventory.runesCollected >= runesToOpen)
        {
            mechSounds.clip = clickSound;
            mechSounds.Play();
            Animator doorAnim = door.GetComponent<Animator>();
            doorAnim.SetTrigger("open");
            doorOpened = true;
            Invoke("CloseDoor", 8f);
        }
    }

    private void CloseDoor()
    {
        doorOpened = false;
    }
}
