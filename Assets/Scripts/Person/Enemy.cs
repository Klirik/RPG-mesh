using UnityEngine;
using UnityEngine.AI;

public class Enemy : AbstractPerson
{
    public AttackControllerEnemy attackController;
    
    private void Update()
    {
        if(attackController.CurTarget)
        {
            var curTargetPos = attackController.CurTarget.transform.position;

            agent.SetDestination(curTargetPos);
        }
    }
}
