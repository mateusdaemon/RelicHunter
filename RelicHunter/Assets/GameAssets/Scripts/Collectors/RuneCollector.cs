using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rune
{
    First,
    Second,
    Third,
    None
}

public class RuneCollector : MonoBehaviour, ICollect
{
    [SerializeField] private Rune runeNumber;

    public void Collect()
    {
        GameManager.Instance.CollectRune(runeNumber);
        Destroy(gameObject);
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
