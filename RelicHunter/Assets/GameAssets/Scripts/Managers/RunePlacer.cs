using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class RunePlacer : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject[] runeSlots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PlaceRune(Rune rune)
    {
        if (rune == Rune.None)
        {
            return false;
        }

        GameManager.Instance.PlaceNewRune(rune);
        EnableNextRune(rune);
        return true;
    }

    private void EnableNextRune(Rune rune)
    {
        foreach (GameObject slot in runeSlots)
        {
            if (!slot.activeSelf)
            {
                slot.SetActive(true);
                break;
            }
        }
    }

    public void Interact()
    {
        Rune runeActive = GameManager.Instance.Inventory.activeRune;

        if (runeActive == Rune.None)
        {
            HudManager.Instance.SetNoRunePop(true);
            return;
        }

        HudManager.Instance.SetPlaceRunePop(true);
        GameManager.Instance.PlaceNewRune(runeActive);
        EnableNextRune(runeActive);
    }
}
