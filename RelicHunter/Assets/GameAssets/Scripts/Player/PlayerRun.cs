using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [SerializeField] private float energyConsumptionRate = 5f;
    [SerializeField] private float energyRegenerationRate = 3f;
    [SerializeField] private float runSpeedMultiplier = 3f;

    private PlayerMove playerMove;
    private float maxEnergy = 15;
    private float currEnergy = 15;
    private bool energyWaste = false;
    private bool canRunAgain = true;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if (energyWaste && currEnergy > 0)
        {
            // Consome energia enquanto está correndo
            currEnergy -= energyConsumptionRate * Time.deltaTime;
            if (currEnergy <= 0)
            {
                currEnergy = 0;
                StopRunning();
            }
        }
        else if (!energyWaste && currEnergy < maxEnergy)
        {
            // Regenera energia suavemente quando não está correndo
            currEnergy += energyRegenerationRate * Time.deltaTime;
            currEnergy = Mathf.Min(currEnergy, maxEnergy); // Limita ao máximo
        }

        // Atualiza a barra de energia no HUD
        HudManager.Instance.SetEnergyAmount(currEnergy / maxEnergy);
    }

    public bool Run(bool isRunning)
    {
        if (currEnergy <= 0 || !canRunAgain) return false;

        energyWaste = isRunning;

        if (isRunning)
        {
            playerMove.MoveSpeed = playerMove.BaseSpeed * runSpeedMultiplier;
        }

        return true;
    }

    private void StopRunning()
    {
        energyWaste = false;
        canRunAgain = false;
        playerMove.MoveSpeed = playerMove.BaseSpeed;
        Invoke("EnableRunAgain", 3f);
    }

    private void EnableRunAgain()
    {
        canRunAgain = true;
    }
}
