using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth = 100f;

    public float health
    {
        get;
        protected set;
    }
    public bool death
    {
        get;
        protected set;
    }
    public event Action OnDeath;

    protected virtual void OnEnable()
    {
        death = false;
        health = startingHealth;
    }

    public virtual void OnDamage(float Damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        health -= Damage;
        if (health <= 0&& !death)
        {
            Die();
        }
    }

    public virtual void RestoreHealth(float newHealth)
    {
        if (death)
        {
            return;
        }
        health += newHealth;
    }

    public virtual void Die()
    {
        if(OnDeath != null)
        {
            OnDeath();
        }
        death = true;
    }
}
