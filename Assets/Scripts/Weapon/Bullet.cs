using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : AbstractBullet
{
    public Rigidbody rbBullet = null;
    public float Damage = 10;

    protected override void OnCollisionEnter(Collision collision)
    {
        var target = collision.gameObject.GetComponent<IDestructable>();

        if (target != null)
        {
            target.TakeDamage((int)Damage);
        }

        Destroy(gameObject);
    }
}
