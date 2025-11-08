using UnityEngine;

public class EnemyDeathNotifier : MonoBehaviour
{
    private EnemySpawner spawner;

    public void Init(EnemySpawner s)
    {
        spawner = s;
    }

    void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.OnEnemyDestroyed(gameObject);
        }
    }
}
