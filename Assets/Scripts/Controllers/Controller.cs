using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public AbstractPerson Person;

    public AbstractWeapon Weapon;

    [Header("Указать номер слоя врагов")]
    public int myEnemyLayerMask = 10;

    private SphereCollider enemyDetectedCollider;
    private float enemyDetectedRange;

    protected List<AbstractPerson> targetEnemies = new List<AbstractPerson>();
    //при обнаружение нового врага мы сортируем список и [0] - самый ближний
    public AbstractPerson CurTarget
    {
        get
        {
            if (targetEnemies.Count > 0)
            {
                return targetEnemies[0];
            }
            return null;
        }
    }

    public bool DetectedEnemy
    {
        get
        {
            return targetEnemies.Count > 0;
        }
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        enemyDetectedCollider = GetComponent<SphereCollider>();

        enemyDetectedRange = enemyDetectedCollider.radius;
    }

    private void Update()
    {
        if (CurTarget)
        {
            Vector3 direction = CurTarget.transform.position - transform.position;

            if (IsDirectVisibleEnemy(direction, myEnemyLayerMask))
            {
                var targetPos = CurTarget.transform.position;
                //NOTE: игнорируется высота врага
                Vector3 dir = new Vector3(targetPos.x, transform.position.y, targetPos.z) - transform.position;
                transform.rotation = Quaternion.LookRotation(dir);

                Weapon.Fire();
            }
        }
    }
        
    public bool IsDirectVisibleEnemy(Vector3 direction, int enemyLayerMask = 10)
    {
        //10 - enemy layer
        int layerMask = 1 << enemyLayerMask;

        var t = Physics.Raycast(transform.position, direction, out RaycastHit hit, enemyDetectedRange, layerMask);

        return t;
    }
}
