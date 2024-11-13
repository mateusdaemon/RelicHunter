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
        if (SceneManager.GetActiveScene().name == "PiramideTest")
        {
            GameObject playerRef = GameObject.FindGameObjectWithTag("Player");
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
        if (scene == "PiramideTest")
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
    }

    internal void PlayerTakeDamage(float damage)
    {
        PlayerData.currentLife-=damage;
        HudManager.Instance.SetLifeAmount(PlayerData.currentLife / PlayerData.life);
        HudManager.Instance.SetLifeValue(PlayerData.currentLife);
    }

    internal void PlayerDied()
    {
        LoadScene("PiramideTest");
        PlayerData.currentLife = PlayerData.life;
        HudManager.Instance.SetLifeAmount(PlayerData.currentLife / PlayerData.life);
        HudManager.Instance.SetLifeValue(PlayerData.currentLife);
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
