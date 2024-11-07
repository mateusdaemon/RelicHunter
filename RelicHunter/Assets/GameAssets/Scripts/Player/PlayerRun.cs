using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [SerializeField] private float energyConsumptionRate = 5f;
    [SerializeField] private float energyRegenerationRate = 3f;
    [SerializeField] private float runSpeedMultiplier = 3f;

    private PlayerMove playerMove;
    private float maxEnergy = 30;
    private float currEnergy = 30;
    private bool energyWaste = false;

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

    public void Run(bool isRunning)
    {
        energyWaste = isRunning;

        if (isRunning)
        {
            playerMove.MoveSpeed = playerMove.BaseSpeed * runSpeedMultiplier;
        }        
    }

    private void StopRunning()
    {
        energyWaste = false;
        playerMove.MoveSpeed = playerMove.BaseSpeed;
    }
}
