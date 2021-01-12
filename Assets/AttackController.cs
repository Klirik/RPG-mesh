using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AttackController : MonoBehaviour
{
    public Player player;

    private float rangeDistance;
    private SphereCollider triggerAttack;
       
    private void Start()
    {
        triggerAttack = GetComponent<SphereCollider>();
        rangeDistance = triggerAttack.radius;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError("fff");

        //10 - enemy layer
        int layerMask = 1 << 10;

        Vector3 direction = other.transform.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, rangeDistance, layerMask))
        {
            Debug.LogError(hit.transform.name);
            
            player.transform.LookAt(hit.transform);            
        }
    }
}
