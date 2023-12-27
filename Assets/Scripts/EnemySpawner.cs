using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private float spawnTimer = 0;
    [SerializeField] private int spawnFrequency = 5;

    void Start()
    {
    }
    void Update()
    {
        SpawnTimer();
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = transform.position;
    }

    private void SpawnTimer()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnEnemy();
            spawnTimer = spawnFrequency;
        }
    }
}
