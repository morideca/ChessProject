using System;
using UnityEngine;

public class FigureAnimationEvents : MonoBehaviour
{
    public event Action OnDealDamage;
    public event Action OnShootProjectile;

    public void DealDamage()
    {
        OnDealDamage?.Invoke();
    }

    public void CreateProjectile()
    {
        OnShootProjectile?.Invoke();
    }
}
