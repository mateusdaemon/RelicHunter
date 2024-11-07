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
            if (playerInput.InteractInput)
            {
                other.gameObject.GetComponent<RunePlacer>().PlaceRune(GameManager.Instance.Inventory.activeRune);
            }
        }
    }
}
