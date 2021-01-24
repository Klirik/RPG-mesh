using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControllerEnemy : AbstractMotionController
{
    public AttackControllerEnemy AttackController;
    
    private void Update()
    {
        if (AttackController.CurTarget)
        {
            var curTargetPos = AttackController.CurTarget.transform.position;

            Agent.SetDestination(curTargetPos);
        }
    }
}
