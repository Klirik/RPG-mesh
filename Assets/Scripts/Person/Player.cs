using UnityEngine;

public class Player : AbstractPerson
{
    [HideInInspector] public Quaternion myRotation;

    private void Start()
    {
        attack = 100;
    }

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
