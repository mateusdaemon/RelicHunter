using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDungeonLevel : MonoBehaviour
{
    public string dgToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LoadScene(dgToLoad);
        }
    }
}
