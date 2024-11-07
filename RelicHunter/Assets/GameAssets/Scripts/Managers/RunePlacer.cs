using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePlacer : MonoBehaviour
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

    public void PlaceRune(Rune rune)
    {
        if (rune == Rune.None) return;
        GameManager.Instance.PlaceNewRune(rune);
        EnableNextRune(rune);
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
}
