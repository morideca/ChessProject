using System.Collections.Generic;
using UnityEngine;

public class FigureAI 
{
    private readonly IAttack figureAttack;
    private readonly IMove figureMove;
    private readonly List<GameObject> targets;
    private readonly float attackRange;
    private readonly GameObject figureGO;
    
    private GameObject target;
    private float distanceToTarget;

    
    public FigureAI(List<GameObject> targets, IAttack figureAttack, IMove figureMove, GameObject figureGO, float attackRange)
    {
        this.figureAttack = figureAttack;
        this.targets = targets;
        this.figureMove = figureMove;
        this.attackRange = attackRange;
        this.figureGO = figureGO;
    }

    public void Tick()
    {
        FindClosestTargetUpdate();
        figureMove.MoveToUpdate(target.transform, figureGO);
        AttackUpdate();
    }

    private void AttackUpdate()
    {
        if (distanceToTarget <= attackRange)
        {
            figureAttack.Attack(target);
        }
    }

    private void FindClosestTargetUpdate()
        { 
            distanceToTarget = 100000000;
        
            foreach (var _target in targets)
            {
                if (_target == null) continue;
                var newDistance = (_target.transform.position - figureGO.transform.position).magnitude;
                if (newDistance < distanceToTarget)
                {
                    distanceToTarget = newDistance;
                    target = _target;
                }
            }
        }
}
