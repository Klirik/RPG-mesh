using System.Collections;
using UnityEngine;

public class EnemySpawner : AbstractSpawner
{
    public bool EndlessSpawn = false;

    public int CountEnemy = 10;
    public float PauseTime = 1f;

    private Coroutine coroutine = null;

    private void Start()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(GenerateEnlessTime());            
        }
    }

    private IEnumerator GenerateEnlessTime()
    {
        if (EndlessSpawn)
        {
            while (EndlessSpawn)
            {
                Spawn();
                yield return new WaitForSeconds(PauseTime);
            }
        }
        else
        {
            while(CountEnemy > 0)
            {
                Spawn();
                CountEnemy--;
                yield return new WaitForSeconds(PauseTime);
            }
        }
        yield return null;
        coroutine = null;
    }    
}

