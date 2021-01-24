using UnityEngine;

public class AttackControllerEnemy : AttackController<Enemy>
{
    private void InitParams()
    {
        myEnemyLayerMask = Person.ConfigManager.Enemy.myEnemyLayerMask;
    }
    protected void Start()
    {
        base.Start();
        InitParams();
    }
}
