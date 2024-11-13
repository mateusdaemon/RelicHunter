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

    private Vector3 lastCheckpoint = Vector3.zero;

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
        SceneManager.sceneLoaded += HandleChangeLoad;
    }

    private void HandleChangeLoad(Scene arg0, LoadSceneMode arg1)
    {
        if (SceneManager.GetActiveScene().name == "Piramide")
        {
            GameObject playerRef = GameObject.FindGameObjectWithTag("Player");

            int i = 0;
            while (i < Inventory.runesCollected)
            {
                FindObjectOfType<RunePlacer>().EnableNextRune(Rune.None);
                i++;
            }

            playerRef.transform.position = lastCheckpoint;
        }
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
        if (scene == "Piramide")
            Cursor.visible = false;
        else 
            Cursor.visible = true;
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

        if (Inventory.runesCollected == 3) // Game is done
        {
            Inventory.runesCollected = 100;
        }
    }

    internal void PlayerTakeDamage(float damage)
    {
        PlayerData.currentLife-=damage;
        HudManager.Instance.SetLifeAmount(PlayerData.currentLife / PlayerData.life);
        HudManager.Instance.SetLifeValue(PlayerData.currentLife);
    }

    internal void PlayerDied()
    {
        HudManager.Instance.DisableHUD();
        Invoke("RespawnPlayer", 3f);
    }

    private void RespawnPlayer()
    {
        LoadScene("Piramide");
        GameObject playerRef = GameObject.FindGameObjectWithTag("Player");
        playerRef.GetComponent<PlayerTakeRune>().DropActiveRune(Inventory.activeRune);
        Inventory.activeRune = Rune.None;
        PlayerData.currentLife = PlayerData.life;
        HudManager.Instance.SetLifeAmount(PlayerData.currentLife / PlayerData.life);
        HudManager.Instance.SetLifeValue(PlayerData.currentLife);
        HudManager.Instance.EnableHUD();
    }

    internal void CurePlayer(float amount)
    {
        if (PlayerData.currentLife + amount > PlayerData.life)
        {
            PlayerData.currentLife = PlayerData.life;
        } else
        {
            PlayerData.currentLife += amount;
        }

        HudManager.Instance.SetLifeAmount(PlayerData.currentLife / PlayerData.life);
        HudManager.Instance.SetLifeValue(PlayerData.currentLife);
    }

    internal void SetLastCheckpoin(Vector3 position)
    {
        lastCheckpoint = position;
    }
}
