using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private int runesToOpen;
    private bool doorOpened = false;
    private Animator doorAnim;

    private void Awake()
    {
        doorAnim = GetComponent<Animator>();
    }

    public bool Open()
    {
        if (doorOpened) return false;

        if (GameManager.Instance.Inventory.runesCollected >=  runesToOpen)
        {
            doorAnim.SetTrigger("open");
            doorOpened = true;
            Invoke("CloseDoor", 12);
        }

        return doorOpened;
    }

    private void CloseDoor()
    {
        doorOpened = false;
    }
}
