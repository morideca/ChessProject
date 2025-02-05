using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private float speed;
    private int damage;

    public void Init(int damage, GameObject target, float speed = 5)
    {
        this.damage = damage;
        this.target = target.transform;
        this.speed = speed;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        var direction = target.transform.position - transform.position;
        direction.y = 0;
        transform.position += direction.normalized * speed * Time.deltaTime;
        transform.forward = direction;

        if (direction.magnitude <= 0.1f)
        {
            target.TryGetComponent<IDamageable>(out IDamageable health);
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
