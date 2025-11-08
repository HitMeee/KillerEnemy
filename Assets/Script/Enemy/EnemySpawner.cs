using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject chickenPrefab;
    public GameObject birdPrefab;
    public GameObject duckPrefab;
    public GameObject bossPrefab;

    [Header("Slots & Timing")]
    public List<Transform> spawnSlots;
    public float moveDuration = 1.2f;
    public float spawnDelay = 0.2f;
    public float nextLevelDelay = 3f;

    [Header("Level Control")]
    public int currentLevel = 1;
    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnLevel(currentLevel));
    }
    public void Init() { 
    }

    IEnumerator SpawnLevel(int level)
    {
        Debug.Log($"🌀 Level {level} bắt đầu");
        enemies.Clear();

        // Nếu là boss level → chỉ sinh 1 boss
        if (level % 5 == 0)
        {
            SpawnBoss();
            yield break; // Dừng luôn coroutine, không spawn quái thường
        }

        // Lấy pattern cho level thường
        List<int> pattern = GetPatternForLevel(level);

        foreach (int index in pattern)
        {
            if (index >= spawnSlots.Count) continue;

            Transform slot = spawnSlots[index];
            Vector3 spawnPos = slot.position + Vector3.up * 5f;

            GameObject prefab = GetEnemyPrefab(level);
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
        Transform centerSlot = spawnSlots[spawnSlots.Count / 2]; // ô giữa
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

    List<int> GetPatternForLevel(int level)
    {
        List<int> p = new List<int>();
        int I(int r, int c) => r * 4 + c;

        switch (level)
        {
            case 1: p.AddRange(new[] { I(1, 1), I(1, 2), I(2, 1), I(2, 2) }); break;
            case 2: p.AddRange(new[] { I(1, 0), I(1, 1), I(1, 2), I(1, 3) }); break;
            case 3: p.AddRange(new[] { I(0, 1), I(1, 2), I(2, 1), I(3, 2) }); break;
            case 4: p.AddRange(new[] { I(0, 0), I(0, 3), I(1, 1), I(2, 2), I(3, 0), I(3, 3) }); break;
            default:
                int count = Mathf.Min(4 + level, spawnSlots.Count);
                while (p.Count < count)
                {
                    int r = Random.Range(0, spawnSlots.Count);
                    if (!p.Contains(r)) p.Add(r);
                }
                break;
        }
        return p;
    }
}
