using UnityEngine;

[CreateAssetMenu(fileName = "Personage", menuName = "ScriptableObjects/Personage", order = 1)]
public class Personage : ScriptableObject
{
    [Header("Характеристики объекта")]
    public int health = 100;
    public float speed = 1f;
    public int attack  = 1;
    public int defence = 1;

    [Header("Слой врага")]
    public int myEnemyLayerMask = 10;
}
