using System;

public interface IHealth
{
    public event Action<int> OnHealthChanged;
    public int HealthPoints { get; }
}
