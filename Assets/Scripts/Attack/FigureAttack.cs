using System.Threading.Tasks;
using UnityEngine;

public class FigureAttack : IAttack
{
    private readonly int damage;
    private readonly int cooldown;

    private bool attackCharged;

    public FigureAttack(int damage, int cooldown, float range)
    {
        this.damage = damage;
        this.cooldown = cooldown;
        attackCharged = true;
    }
    
    public void Attack(GameObject target)
    {
        if(attackCharged)
        {
            target.GetComponent<IDamageable>().TakeDamage(damage);
            ChargeAttack();
        }
    }

    private async void ChargeAttack()
    {
        attackCharged = false;
        await Task.Delay(cooldown * 1000);
        attackCharged = true;
    }
}
