using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    public GameObject chickenPrefab;
    public GameObject birdPrefab;
    public GameObject duckPrefab;
    public GameObject bossPrefab;

    public List<Transform> spawnSlots;
    public float moveDuration = 1.2f;
    public float spawnDelay = 0.2f;
    public float nextLevelDelay = 3f;

    public int currentLevel = 1;
    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnLevel(currentLevel));
    }

    public void Init() { }

    IEnumerator SpawnLevel(int level)
    {
        Debug.Log($"🌀 Level {level} bắt đầu");
        enemies.Clear();

        if (level % 5 == 0)
        {
            SpawnBoss();
            yield break;
        }

        int baseCount = 3; 
        int spawnCount = Mathf.Min(spawnSlots.Count, baseCount + (level - 1));

        GameObject prefab = GetEnemyPrefab(level);

        for (int i = 0; i < spawnCount; i++)
        {
            if (i >= spawnSlots.Count) break;

            Transform slot = spawnSlots[i];
            Vector3 spawnPos = slot.position + Vector3.up * 5f;

            GameObject enemy = Instantiate(prefab, spawnPos, Quaternion.identity);

            enemy.transform.DOMove(slot.position, moveDuration).SetEase(Ease.OutQuad);
            enemy.transform.localScale = Vector3.zero;
            enemy.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

            enemies.Add(enemy);

            EnemyBase eb = enemy.GetComponent<EnemyBase>();
            if (eb != null) eb.spawner = this;

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnBoss()
    {
        Debug.Log("👑 Spawn Boss!");
        Transform centerSlot = spawnSlots[Mathf.Clamp(spawnSlots.Count / 2, 0, spawnSlots.Count - 1)];
        Vector3 spawnPos = centerSlot.position + Vector3.up * 6f;

        GameObject boss = Instantiate(bossPrefab, spawnPos, Quaternion.identity);
        boss.transform.DOMove(centerSlot.position, moveDuration).SetEase(Ease.OutBack);
        boss.transform.localScale = Vector3.zero;
        boss.transform.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutBack);

        enemies.Add(boss);

        EnemyBase eb = boss.GetComponent<EnemyBase>();
        if (eb != null) eb.spawner = this;
    }

    public void OnEnemyDestroyed(GameObject enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            Debug.Log($"✅ Level {currentLevel} hoàn thành");
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(nextLevelDelay);
        currentLevel++;
        StartCoroutine(SpawnLevel(currentLevel));
    }

    GameObject GetEnemyPrefab(int level)
    {
        if (level % 5 == 0) return bossPrefab;
        if (level < 3) return chickenPrefab;
        if (level < 6) return birdPrefab;
        return duckPrefab;
    }
}