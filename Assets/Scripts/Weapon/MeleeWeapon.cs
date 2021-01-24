using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : AbstractWeapon
{
    private bool canBite = false;
    private AbstractPerson target;

    private void OnTriggerEnter(Collider other)
    {
        var tempTarget = other.GetComponent<AbstractPerson>();

        if (tempTarget)
        {
            target = tempTarget;
            canBite = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<AbstractPerson>())
        {
            canBite = false;
        }
    }

    public override void Fire()
    {
        Vector3 direction = attackController.CurTarget.transform.position - transform.position;

        if (!canBite || !attackController.DetectedEnemy || attackController.IsDirectVisibleEnemy(direction))
        {
            return;
        }

        int layerMask = 1 << attackController.myEnemyLayerMask;

        if (fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(StartFire(fireRate, layerMask));
        }
    }

    private Coroutine fireCoroutine = null;
    private IEnumerator StartFire(float fireRate, int layerMask)
    {        
        while (canBite)
        {
            target.TakeDamage((int)damage, attackController.Person.Attack);

            yield return new WaitForSeconds(fireRate);
        }

        yield return new WaitForEndOfFrame();

        fireCoroutine = null;
    }

    public override void Reload()
    {
        //No reload!
    }
}
