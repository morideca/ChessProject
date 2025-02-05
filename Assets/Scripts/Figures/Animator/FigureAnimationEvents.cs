using System;
using UnityEngine;

public class FigureAnimationEvents : MonoBehaviour
{
    public event Action OnDealtDamage;
    public event Action OnCreatedProjectile;

    public void DealDamage()
    {
        OnDealtDamage?.Invoke();
    }

    public void CreateProjectile()
    {
        OnCreatedProjectile?.Invoke();
    }
}
