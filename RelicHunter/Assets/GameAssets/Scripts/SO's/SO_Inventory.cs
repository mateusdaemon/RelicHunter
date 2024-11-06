using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Inventory", menuName = "ScriptableObjects/SO_Inventory")]
public class SO_Inventory : ScriptableObject, ISerializationCallbackReceiver
{
    public Rune activeRune;

    public void OnAfterDeserialize()
    {
        activeRune = Rune.None;
    }

    public void OnBeforeSerialize()
    {
        
    }

    public void SetActiveRune(Rune runeType)
    {
        activeRune = runeType;
    }

    public Rune GetActiveRune()
    {
        return activeRune;
    }
}
