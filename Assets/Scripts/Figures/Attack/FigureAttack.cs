using System.Threading.Tasks;
using UnityEngine;

public class FigureAttack : IAttack
{
    private readonly int damage;
    private readonly int cooldown;
    private readonly Animator animator;
    private readonly int attack = Animator.StringToHash("Attack");
    private readonly FigureAnimationEvents animationEvents;

    private GameObject target;

    private bool attackCharged;

    public FigureAttack(FigureAnimationEvents animationEvents, Animator animator, int damage, int cooldown)
    {
        this.animationEvents = animationEvents;
        this.animator = animator;
        this.damage = damage;
        this.cooldown = cooldown;
        attackCharged = true;
        animationEvents.OnDealtDamage += DealDamage;
    }
    
    public void Attack(GameObject target)
    {
        this.target = target;
        if(attackCharged)
        {
            animator.SetTrigger(attack);
            ChargeAttack();
        }
    }

    private void DealDamage()
    {
        if (target == null) return;
        target.GetComponent<IDamageable>().TakeDamage(damage);
    }

    private async void ChargeAttack()
    {
        attackCharged = false;
        await Task.Delay(cooldown * 1000);
        attackCharged = true;
    }
}
