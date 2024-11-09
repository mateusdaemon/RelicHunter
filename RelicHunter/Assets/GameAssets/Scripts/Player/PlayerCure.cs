using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCure : MonoBehaviour, ICure
{
    public void Cure(float amount)
    {
        GameManager.Instance.CurePlayer(amount);       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
