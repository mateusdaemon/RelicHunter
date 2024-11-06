using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public SO_Inventory Inventory;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Cursor.visible = false;
    }

    public void CollectRune(Rune runeType)
    {
        Inventory.SetActiveRune(runeType);
        
        var player = FindObjectsOfType<MonoBehaviour>().OfType<ITakeRune>();

        foreach (var rune in player)
        {
            rune.TakeRune(runeType);
        }
    }
}
