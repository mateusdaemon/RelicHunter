using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITakeRune
{
    void TakeRune(Rune runeType);
    Rune DropActiveRune();
}
