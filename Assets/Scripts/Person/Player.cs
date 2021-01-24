using UnityEngine;

public class Player : AbstractPerson
{
    public MotionControllerPlayer Legs;
    private void Start()
    {
        Health = ConfigManager.Player.health;
        Attack = ConfigManager.Player.attack;
        Defence = ConfigManager.Player.defence;
        Speed = ConfigManager.Player.speed;

        Legs.Agent.speed = Speed;        
    }

}
