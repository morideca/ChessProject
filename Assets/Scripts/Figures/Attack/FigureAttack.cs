using System.Threading.Tasks;
using UnityEngine;

public class FigureAttack : IAttack
{
    private readonly int damage;
    private readonly int cooldown;
    private readonly Animator animator;
    private readonly int attack = Animator.StringToHash("Attack");
    private readonly FigureAnimationEvents animationEvents;

    private readonly GameObject projectile;
    private readonly Transform gun;

    private GameObject target;

    private bool attackCharged;

    public FigureAttack(FigureAnimationEvents animationEvents, Animator animator, int damage, int cooldown,
        bool isRanged = false, GameObject projectile = null, Transform gun = null)
    {
        this.gun = gun;
        this.projectile = projectile;
        this.animationEvents = animationEvents;
        this.animator = animator;
        this.damage = damage;
        this.cooldown = cooldown;
        attackCharged = true;
        if (!isRanged)
        {
            animationEvents.OnDealDamage += DealDamage;
        }
        else
        {
            animationEvents.OnShootProjectile += ShootProjectile;
        }
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

    private void ShootProjectile()
    {
        var _projectile = Object.Instantiate(projectile, gun.position, Quaternion.identity);
        _projectile.GetComponent<Projectile>().Init(damage, target);
    }

    private async void ChargeAttack()
    {
        attackCharged = false;
        await Task.Delay(cooldown * 1000);
        attackCharged = true;
    }
}
