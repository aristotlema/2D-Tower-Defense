using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected float attackRange = 4;

    [SerializeField] protected LayerMask whatIsEnemy;

    protected RaycastHit2D isEnemyDetected;
    protected GameObject currentTarget;

    [Header("Tower Damage")]
    [SerializeField] protected float attackFrequency = 1f;
    [SerializeField] protected int attackDamage = 25;
    protected float attackTimer = 0;
    

    protected Animator anim;
    protected bool isShooting = false;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        EnemyInRangeCheck();
        TargetEnemy();
        AnimationController();
    }

    private void EnemyInRangeCheck()
    {
        isEnemyDetected = Physics2D.CircleCast(transform.position, attackRange, Vector2.zero, whatIsEnemy);
    }

    private void TargetEnemy()
    {
        if (isEnemyDetected)
        {
            // if there is not already a target, but one is found, set as current target
            if (!currentTarget)
            {
                currentTarget = isEnemyDetected.transform.gameObject;
                
            }
            //attack current target
            else if (currentTarget)
            {
                DamageEnemy();

                transform.up = currentTarget.transform.position - transform.position;

                //clear current target once target is no longer in range
                if (Vector3.Distance(transform.position, currentTarget.transform.position) > attackRange)
                {
                    
                    currentTarget = null;
                }
            }
        }
    }

    protected void DamageEnemy()
    {
        

        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            anim.SetTrigger("Shoot");
            currentTarget.GetComponent<Enemy>().DealDamageToTower(attackDamage);
            attackTimer = attackFrequency;
        }
    }

    protected void AnimationController()
    {
        
    }
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
