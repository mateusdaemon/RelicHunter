using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceRune : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerPlaceRune placeRune;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        placeRune = GetComponent<PlayerPlaceRune>();
    }

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<RunePlacer>())
        {
            HudManager.Instance.SetInteractPop(true);
            if (playerInput.InteractInput)
            {
                if (other.gameObject.GetComponent<RunePlacer>().PlaceRune(GameManager.Instance.Inventory.activeRune))
                {
                    HudManager.Instance.SetPlaceRunePop(true);
                } else
                {
                    HudManager.Instance.SetNoRunePop(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<RunePlacer>())
        {
            HudManager.Instance.SetInteractPop(false);
        }
    }
}
