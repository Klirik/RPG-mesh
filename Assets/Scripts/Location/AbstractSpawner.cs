using System;
using UnityEngine;

public abstract class AbstractSpawner : MonoBehaviour
{
    public event Action OnSpawn = delegate { };

    public GameObject ObjPrefab;    
    protected void Spawn()
    {
        Instantiate(ObjPrefab, transform.position, Quaternion.identity, null);
        OnSpawn?.Invoke();
    }
}
