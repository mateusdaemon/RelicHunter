using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [Header("Life UI")]
    public TextMeshProUGUI lifeText;
    public Image lifeBar;
    public Image energyBar;

    [Header("Runes Slot")]
    public GameObject first;
    public GameObject second;
    public GameObject third;

    public static HudManager Instance { get; private set; }

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

    public void SetEnergyAmount(float amount)
    {
        energyBar.fillAmount = amount;
    }
}
