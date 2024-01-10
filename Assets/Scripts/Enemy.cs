using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform[] wayPoints;
    protected int wayPointCurrentIndex = 0;

    [SerializeField] protected float moveSpeed = 1f;

    [SerializeField] private int healthPool = 100;

    void Update()
    {
        Movement();
        CheckIfTowerIsDeadAndKill();
    }

    public void DealDamageToTower(int damageTaken)
    {
        healthPool -= damageTaken;
        // Debug.Log(gameObject.GetInstanceID().ToString() + "Health: " + healthPool);
    }

    protected void CheckIfTowerIsDeadAndKill()
    {
        if (healthPool <= 0)
            Destroy(gameObject);
    }

    private void Movement()
    {
        if (wayPointCurrentIndex < wayPoints.Length)
        {
            Transform currentWayPoint = wayPoints[wayPointCurrentIndex];

            transform.position = Vector2.MoveTowards(transform.position, currentWayPoint.transform.position, moveSpeed * Time.deltaTime);

            transform.up = currentWayPoint.transform.position - transform.position;

            if (transform.position == currentWayPoint.transform.position)
            {
                wayPointCurrentIndex += 1;
            }
        }
    }
}
