using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeRune : MonoBehaviour
{
    public GameObject firstRune;
    public GameObject secondRune;
    public GameObject thirdRune;

    public void DropActiveRune(Rune runeType)
    {
        switch (runeType)
        {
            case Rune.First:
                firstRune.SetActive(false);
                break;
            case Rune.Second:
                secondRune.SetActive(false);
                break;
            case Rune.Third:
                thirdRune.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void TakeRune(Rune runeType)
    {
        switch (runeType)
        {
            case Rune.First:
                firstRune.SetActive(true);
                break;
            case Rune.Second:
                secondRune.SetActive(true);
                break;
            case Rune.Third:
                thirdRune.SetActive(true);
                break;
            default:
                break;
        }
    }
}
