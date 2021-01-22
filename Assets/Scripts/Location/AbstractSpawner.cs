using UnityEngine;

public abstract class AbstractSpawner : MonoBehaviour
{
    public GameObject ObjPrefab;
    
    protected void Spawn()
    {
        Instantiate(ObjPrefab, transform.position, Quaternion.identity, transform);
    }
}
