using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public SO_Inventory Inventory;
    public SO_PlayerData PlayerData;

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
    }

    private void Start()
    {
        CheckEnableCursor(SceneManager.GetActiveScene().name);
    }

    public void CollectRune(Rune runeType)
    {
        Inventory.SetActiveRune(runeType);

        var player = FindObjectsOfType<PlayerTakeRune>();

        foreach (var rune in player)
        {
            rune.TakeRune(runeType);
        }
    }

    public void LoadScene(string sceneName)
    {
        CheckEnableCursor(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    private void CheckEnableCursor(string scene)
    {
        if (scene == "TestPointClick")
            Cursor.visible = true;
        else 
            Cursor.visible = false;
    }

    internal void PlaceNewRune(Rune runeType)
    {
        Inventory.runesCollected++;
        Inventory.activeRune = Rune.None;

        var player = FindObjectsOfType<PlayerTakeRune>();

        foreach (var rune in player)
        {
            rune.DropActiveRune(runeType);
        }
    }

    internal void PlayerTakeDamage(float damage)
    {
        PlayerData.life-=damage;
    }

    internal void PlayerDied()
    {
        
    }
}
