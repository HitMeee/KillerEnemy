using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // Prefab quái
    public float spawnInterval = 2f; // Thời gian giữa 2 lần sinh quái
    public Transform spawnPoint;     // Vị trí sinh quái (có thể gán empty object)
    public float spawnRangeX ;   // Phạm vi random theo trục X

    public bool autoSpawn = true;    // Tự động sinh liên tục hay không
    public float timer = 0f;

    public void Init()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        if (!autoSpawn) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    public void SpawnEnemy()
    {

        float randomX = Random.Range(-spawnRangeX, spawnRangeX);


        Vector3 spawnPos = spawnPoint != null ? spawnPoint.position : transform.position;

 
        spawnPos.x += randomX;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
