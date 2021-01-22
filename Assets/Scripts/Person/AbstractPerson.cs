using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class AbstractPerson : MonoBehaviour, IDestructable
{
    public event Action<GameObject> OnDestroyObj = delegate { }; 
       
    [Header("Характеристики персонажа")]
    public NavMeshAgent agent;
    public int health { get; protected set; } = 100;
    public float speed { get; protected set; } = 1f;
    public int attack { get; protected set; } = 1;
    public int defence { get; protected set; } = 1;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            OnDestroyObj?.Invoke(gameObject);
            Destroy(gameObject);
        }
        Debug.LogError(health);
    }
}
