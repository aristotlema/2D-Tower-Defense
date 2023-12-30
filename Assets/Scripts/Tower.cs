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

    [SerializeField] protected AudioClip[] gunSoundArr;
    protected AudioSource gunAudioSource; 


    protected Animator anim;
    protected bool isShooting = false;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        gunAudioSource = GetComponent<AudioSource>();
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
            // if there is not already a target, but one is found, set as current target
            if (!currentTarget)
            {
                currentTarget = isEnemyDetected.transform.gameObject;
                
            }
            //attack current target
            else if (currentTarget)
            {
                DamageEnemy();
                //track enemyy position
                transform.up = currentTarget.transform.position - transform.position;
                ClearTargetIfNoLongerInRange();
            }
        }
    }

    private void ClearTargetIfNoLongerInRange()
    {
        if (Vector3.Distance(transform.position, currentTarget.transform.position) > attackRange)
        {
            currentTarget = null;
        }
    }

    protected void DamageEnemy()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            anim.SetTrigger("Shoot");
            PlayGunAudio();
            currentTarget.GetComponent<Enemy>().DealDamageToTower(attackDamage);
            attackTimer = attackFrequency;
        }
    }

    protected void PlayGunAudio()
    {
        gunAudioSource.clip = gunSoundArr[Random.Range(0, gunSoundArr.Length - 1)];
        gunAudioSource.Play();
    }
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
