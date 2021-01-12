using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [HideInInspector] public Quaternion myRotation;

    public NavMeshAgent agent;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

        }

    }
}
