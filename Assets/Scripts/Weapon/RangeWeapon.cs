using System.Collections;

using UnityEngine;

public class RangeWeapon : AbstractWeapon
{
    public GameObject BulletPrefab = null;
    public GameObject BulletSpawn = null;
    
    private bool meleeAttack = false;

    private bool canShoot = false;

    public float bulletSpeed = 5f;
    public float weaponDamage = 10f;

    protected void Awake()
    {
        base.Awake();        
    }

    private Vector3 targetPos = Vector3.zero;

    public override void Fire()
    {
        targetPos = attackController.CurTarget.transform.position;

        canShoot = attackController.IsDirectVisibleEnemy(targetPos - attackController.transform.position);

        if (!canShoot)
        {
            return;
        }       
        
        if (fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(Shoot(fireRate));
        }
    }

    private Coroutine fireCoroutine = null;
    private IEnumerator Shoot(float fireRate)
    {
        while (canShoot && attackController.CurTarget)
        {
            Vector3 direction = attackController.CurTarget.transform.position - BulletSpawn.transform.position;
            var obj = Instantiate(BulletPrefab, BulletSpawn.transform.position, Quaternion.identity, null);
            var bullet = obj.GetComponent<Bullet>();

            bullet.Damage = weaponDamage * attackController.Person.attack;
            bullet.rbBullet.AddForce(bulletSpeed * direction.normalized, ForceMode.Impulse);

            yield return new WaitForSeconds(fireRate);

            canShoot = attackController.IsDirectVisibleEnemy(targetPos - attackController.transform.position);
        }

        fireCoroutine = null;
    }
    
    public override void Reload()
    {
        //No reload!
    }
}
