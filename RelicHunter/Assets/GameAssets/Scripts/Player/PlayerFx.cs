using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFx : MonoBehaviour
{
    [SerializeField] GameObject bloodParticles;

    public void BloodShow()
    {
        foreach (ParticleSystem blood in bloodParticles.GetComponentsInChildren<ParticleSystem>())
        {
            blood.Play();
        }
    }
}
