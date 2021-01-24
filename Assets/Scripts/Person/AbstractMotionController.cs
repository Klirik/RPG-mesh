using UnityEngine;
using UnityEngine.AI;

public abstract class AbstractMotionController : MonoBehaviour
{
    [HideInInspector] public Quaternion myRotation;

    public NavMeshAgent Agent = null;   
}
