using UnityEngine;
using UnityEngine.AI;

public class FigureMove : IMove
{
    private readonly NavMeshAgent agent;

    public FigureMove(NavMeshAgent agent, float speed)
    {
        this.agent = agent;
        agent.speed = speed;
    }

    public void MoveToUpdate(Transform target)
    {
        agent.SetDestination(target.position);
    }
}
