using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TottemHealer : MonoBehaviour
{
    private bool cureNow = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ICure>() != null)
        {
            InvokeRepeating("CureNow", 1f, 2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ICure>() != null)
        {
            CancelInvoke("CureNow");
            cureNow = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<ICure>() != null)
        {
            if (cureNow)
            {
                other.gameObject.GetComponent<ICure>().Cure(1f);
                cureNow = false;
            }
        }
    }

    private void CureNow()
    {
        cureNow = true;
    }
}
