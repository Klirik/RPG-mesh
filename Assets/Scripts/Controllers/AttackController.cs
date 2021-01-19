using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AttackController<T> : Controller
{
    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = other.transform.position - transform.position;                
        var enemy = other.GetComponent<AbstractPerson>();

        if (enemy && !(enemy is T))
        {
            targetEnemies.Add(enemy);
            targetEnemies.Sort((x, y) => x.transform.position.magnitude.CompareTo(y.transform.position.magnitude));

            enemy.OnDestroyObj += DelTarget;
        }
    }

    private void DelTarget(GameObject obj)
    {
        var enemy = obj.GetComponent<AbstractPerson>();

        if (enemy && !(enemy is T))
        {
            enemy.OnDestroyObj -= DelTarget;
            targetEnemies.Remove(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DelTarget(other.gameObject);        
    }
}
