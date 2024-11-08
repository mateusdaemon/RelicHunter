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

    [Header("Popups")]
    public GameObject interactPop;
    public GameObject noRunePop;
    public GameObject placeRunePop;
    public GameObject cantOpenDoorPop;

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

    public void SetInteractPop(bool show)
    {
        interactPop.SetActive(show);
    }

    public void SetNoRunePop(bool show)
    {
        noRunePop.SetActive(show);
    }

    public void SetPlaceRunePop(bool show)
    {
        placeRunePop.SetActive(show);
    }

    public void SetCantOpenDoor(bool show)
    {
        cantOpenDoorPop.SetActive(show);
    }
}
