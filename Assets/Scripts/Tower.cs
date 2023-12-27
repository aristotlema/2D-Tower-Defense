using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected float attackRange = 4;

    [SerializeField] protected LayerMask whatIsEnemy;

    protected RaycastHit2D isEnemyDetected;
    protected GameObject currentTarget;

    void Start()
    {
        
    }

    void Update()
    {
        EnemyInRangeCheck();
        TargetEnemy();
    }

    private void EnemyInRangeCheck()
    {
        isEnemyDetected = Physics2D.CircleCast(transform.position, attackRange, Vector2.zero, whatIsEnemy);
    }

    private void TargetEnemy()
    {
        if (isEnemyDetected)
        {
            if (!currentTarget)
            {
                currentTarget = isEnemyDetected.transform.gameObject;
            }
            else if (currentTarget)
            {
                Debug.Log("Got a live one" + currentTarget.name);

                transform.right = currentTarget.transform.position - transform.position;

                if (Vector3.Distance(transform.position, currentTarget.transform.position) > attackRange)
                {
                    currentTarget = null;
                }
            }
        }
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
