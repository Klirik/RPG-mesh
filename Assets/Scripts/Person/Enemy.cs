public class Enemy : AbstractPerson
{
    public AttackControllerEnemy AttackController;
    
    protected void Awake()
    {
        base.Awake();

        Health = ConfigManager.Enemy.health;
        Attack = ConfigManager.Enemy.attack;
        Defence = ConfigManager.Enemy.defence;
        Speed = ConfigManager.Enemy.speed;
    }   
}
