using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class RunePlacer : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject[] runeSlots;
    [SerializeField] private AudioClip failSound;
    [SerializeField] private AudioClip succSound;
    [SerializeField] private AudioSource sounds;

    public void EnableNextRune(Rune rune)
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
            sounds.clip = failSound;
            sounds.Play();
            HudManager.Instance.SetNoRunePop(true);
        } else
        {
            HudManager.Instance.SetPlaceRunePop(true);
            GameManager.Instance.PlaceNewRune(runeActive);

            sounds.clip = succSound;
            sounds.Play();

            EnableNextRune(runeActive);
        }
    }
}
