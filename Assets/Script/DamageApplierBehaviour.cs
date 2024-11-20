using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageApplierBehaviour : MonoBehaviour
{
    public float damage;

    public void ApplyDamage(GameObject instigator)
    {
        IDamageable damageable = instigator.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }
}
