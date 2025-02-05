using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FigureBattleInstance : MonoBehaviour
{
    public event Action<bool, FigureBattleInstance> OnDeath;
    
    private NavMeshAgent navMeshAgent;
    private FigureAI figureAI;
    private Animator animator;
    
    public FigureType FigureType { get; private set; }
    
    private bool isWhite;
    
    private void FixedUpdate()
    {
        figureAI.Tick();
    }

    public void Init(FigureType figureType, FigureConfig config, GameObject healthBarPrefab, List<GameObject> enemies, bool isWhite)
    {
        navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        animator = gameObject.GetComponentInChildren<Animator>();
        navMeshAgent.stoppingDistance = config.AttackRange - 0.1f;
        this.isWhite = isWhite;
        InitAI(config, enemies);
        InitHealth(config, healthBarPrefab);
        FigureType = figureType;
    }

    private void InitAI(FigureConfig config, List<GameObject> enemies)
    {
        FigureAttack figureAttack = new(animator, config.Damage,  config.AttackCooldown);
        FigureMove figureMove = new(animator, navMeshAgent, config.MoveSpeed);
        figureAI = new(enemies, figureAttack, figureMove, gameObject, config.AttackRange);
    }

    private void InitHealth(FigureConfig config, GameObject healthBarPrefab)
    {
        Health health = gameObject.AddComponent<Health>();
        health.Init(config.Health);
        health.OnDeath += Destroy;
        InstantiateHealthBar(healthBarPrefab, health);
    }

    private void InstantiateHealthBar(GameObject healthBarPrefab, Health health)
    {
        Vector3 position = transform.position +Vector3.up * 2;
        var healthBarPrebaf = Instantiate(healthBarPrefab, position, Quaternion.identity, transform);
        var healthBar = healthBarPrebaf.GetComponent<HealthBar>();
        healthBar.Init(health);
    }

    private void Destroy()
    {
        OnDeath?.Invoke(isWhite, this);
        Destroy(gameObject);
    }
}