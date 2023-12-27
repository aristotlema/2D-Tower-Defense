using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform[] wayPoints;
    protected int wayPointCurrentIndex = 0;

    [SerializeField] protected float moveSpeed = 1f;

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (wayPointCurrentIndex < wayPoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[wayPointCurrentIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == wayPoints[wayPointCurrentIndex].transform.position)
            {
                wayPointCurrentIndex += 1;
            }
        }
    }
}
