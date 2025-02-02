using System;
using UnityEngine;

public class Health: MonoBehaviour, IHealth, IDamageable
{
    public event Action<int> OnHealthChanged;
    public event Action OnDeath;
    public int HealthPoints { get; private set; }

    public void Init(int healthPoints)
    {
        HealthPoints = healthPoints;
    }
        
    public void TakeDamage(int amount)
    {
        HealthPoints -= amount;
        OnHealthChanged?.Invoke(HealthPoints);
        if (HealthPoints <= 0)
        {
            OnDeath?.Invoke();
        }

    }
}
