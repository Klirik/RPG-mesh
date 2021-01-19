using UnityEngine;
public abstract class AbstractBullet : MonoBehaviour
{
    protected abstract void OnCollisionEnter(Collision collision);
    
}