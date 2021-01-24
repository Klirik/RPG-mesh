using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class AbstractPerson : MonoBehaviour, IDestructable
{
    private const float DIE_DELAY = 1f;

    public event Action<GameObject> OnDestroyObj = delegate { }; 
        
    public int Health { get; protected set; } = 100;
    public int Attack { get; protected set; } = 1;
    public int Defence { get; protected set; } = 1;
    public float Speed { get; protected set; } = 1f;

    protected float CharacContribution = 0.5f;

    public ConfigManager ConfigManager { get; private set; } = null;

    protected void Awake()
    {
        ConfigManager = FindObjectOfType<ConfigManager>();
        if (ConfigManager)
        {
            InitGlobalParams();
        }
    }

    private void InitGlobalParams()
    {
        CharacContribution = ConfigManager.Global.CharacteristicContribution;
    }

    public void TakeDamage(int damage, int enemyAttack)
    {
        Health -= CalcDamage(damage, enemyAttack);

        if(Health <= 0)
        {
            OnDestroyObj?.Invoke(gameObject);
            die = StartCoroutine(DieProcess());
        }
    }

    private Coroutine die = null;

    private IEnumerator DieProcess()
    {
        yield return new WaitForSeconds(DIE_DELAY);
        Destroy(gameObject);
        die = null;
    }

    private int CalcDamage(int damage, int enemyAttack)
    {
        return (damage + (int)(damage * (enemyAttack - Defence) * CharacContribution));
    }
}
