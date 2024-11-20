using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour, IDamageable
{
    public float health { get; private set; }
    [SerializeField] float maxHealth;

    public UnityEvent<float> onDamage;

    public UnityEvent onDied;

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (onDamage != null)
        {
            onDamage.Invoke(damage);
        }

        if (health <= 0)
        {
            health = 0;
            if (onDied != null)
            {
                onDied.Invoke();
            }
        }
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

}
