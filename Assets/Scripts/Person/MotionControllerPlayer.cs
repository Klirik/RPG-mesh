using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControllerPlayer : AbstractMotionController
{
    public int MapLayerMask = 0;

    private void Start()
    {
        MapLayerMask = 1 << MapLayerMask;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, float.MaxValue, MapLayerMask))
            {
                Debug.LogError("1");
                Agent.SetDestination(hit.point);
            }
        }
    }
}
