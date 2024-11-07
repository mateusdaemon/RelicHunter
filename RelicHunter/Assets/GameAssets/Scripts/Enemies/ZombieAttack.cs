using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour, IAttack
{
    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float damage;

    public void Attack()
    {
        Collider[] hitTargets = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);
        foreach (var target in hitTargets)
        {
            // Obtém o componente que implementa ITakeDamage no alvo detectado
            ITakeDamage damageable = target.GetComponent<ITakeDamage>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage); // Aplica dano
            }
        }
    }
}
