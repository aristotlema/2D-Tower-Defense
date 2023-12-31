using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected float attackRange = 4;

    [SerializeField] protected LayerMask whatIsEnemy;

    [SerializeField] private float rangeCheckFrequency = 0.25f;
    private float rangeCheckTimer = 0;
    protected RaycastHit2D isEnemyDetected;
    protected GameObject currentTarget = null;

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
        rangeCheckTimer -= Time.deltaTime;
        if (rangeCheckTimer < 0)
        {
            isEnemyDetected = Physics2D.CircleCast(transform.position, attackRange, Vector2.zero, whatIsEnemy);
            rangeCheckTimer = rangeCheckFrequency;
        }
    }

    private void TargetEnemy()
    {
        if (isEnemyDetected)
        {
            Debug.Log($"{gameObject.GetInstanceID().ToString()} Detected enemy");

            // if there is not already a target, but one is found, set as current target
            if (!currentTarget)
            {
                currentTarget = isEnemyDetected.transform.gameObject;
            }
            //attack current target
            else if (currentTarget)
            {
                //track enemyy position
                transform.up = currentTarget.transform.position - transform.position;
                DamageEnemy();
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
        Enemy tempTarget = currentTarget.GetComponent<Enemy>();

        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            anim.SetTrigger("Shoot");
            PlayRandomGunAudio();
            tempTarget.DealDamageToTower(attackDamage);
            attackTimer = attackFrequency;
        }
    }

    protected void PlayRandomGunAudio()
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
