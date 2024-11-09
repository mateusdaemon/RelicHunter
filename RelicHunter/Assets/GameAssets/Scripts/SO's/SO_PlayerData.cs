using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayerData", menuName = "ScriptableObjects/SO_PlayerData")]
public class SO_PlayerData : ScriptableObject, ISerializationCallbackReceiver
{
    public float life = 10;
    public float currentLife = 10;

    public void OnAfterDeserialize()
    {
        life = 10;
        currentLife = 10;
    }

    public void OnBeforeSerialize()
    {
        
    }
}
