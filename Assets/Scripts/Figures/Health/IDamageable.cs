using System;

public interface IDamageable
{
    public event Action OnDeath;
    public void TakeDamage(int amount);
}
