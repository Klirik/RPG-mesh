public class AttackControllerPlayer : AttackController<Player>
{
    private void InitParams()
    {
        myEnemyLayerMask = Person.ConfigManager.Player.myEnemyLayerMask;
    }

    protected void Start()
    {
        base.Start();
        InitParams();
    }
}
