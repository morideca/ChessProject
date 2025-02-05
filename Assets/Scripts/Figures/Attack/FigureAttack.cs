using System.Threading.Tasks;
using UnityEngine;

public class FigureAttack : IAttack
{
    private readonly int damage;
    private readonly int cooldown;
    private readonly Animator animator;
    private readonly int attack = Animator.StringToHash("Attack");

    private bool attackCharged;

    public FigureAttack(Animator animator, int damage, int cooldown)
    {
        this.animator = animator;
        this.damage = damage;
        this.cooldown = cooldown;
        attackCharged = true;
    }
    
    public void Attack(GameObject target)
    {
        if(attackCharged)
        {
            animator.SetTrigger(attack);
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
