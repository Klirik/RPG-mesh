using UnityEngine;

public class Player : AbstractPerson
{
    [HideInInspector] public Quaternion myRotation;

    [Header("Слой локации")]
    public int layerMask = 0;
    private void Start()
    {
        attack = 100;
        layerMask = 1 << layerMask;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, float.MaxValue,layerMask))
            {
                agent.SetDestination(hit.point);
            }
            else
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
