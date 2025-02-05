using UnityEngine;
using UnityEngine.AI;

public class FigureMove : IMove
{
    private readonly NavMeshAgent agent;
    private readonly float rotationSpeed = 5f;
    private readonly Animator animator;
    private readonly int running = Animator.StringToHash("Running");

    public FigureMove(Animator animator, NavMeshAgent agent, float speed)
    {
        this.animator = animator;
        this.agent = agent;
        agent.speed = speed;
        agent.updateRotation = false;
    }

    public void MoveToUpdate(Transform target, GameObject figureGameObject)
    {
        agent.SetDestination(target.position);
        Vector3 direction = target.position - figureGameObject.transform.position;
        direction.y = 0;
        if (direction.sqrMagnitude > 0.01f) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            figureGameObject.transform.rotation = Quaternion.Slerp(figureGameObject.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        animator.SetBool(running, (agent.velocity.sqrMagnitude > 0.01f)); 
    }
}
