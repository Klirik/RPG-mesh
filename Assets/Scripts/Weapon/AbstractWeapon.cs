using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public abstract class AbstractWeapon : MonoBehaviour
{
    protected SphereCollider shotRange;
    
    public float shotDistance { get; private set; } = 0f;

    public Controller attackController = null;

    protected float fireRate = 1f;
    protected float fireDistance = 0;

    protected float damage = 10f;

    protected void Awake()
    {
        shotRange = GetComponent<SphereCollider>();
        shotDistance = shotRange.radius;
    }

    public abstract void Fire();
    public abstract void Reload();
}
