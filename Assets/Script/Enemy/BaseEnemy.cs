
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int hp = 3;
    protected bool isAlive = true;

    [HideInInspector] public EnemySpawner spawner;

    public virtual void TakeDamage(int damage)
    {
        if (!isAlive) return;

        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        isAlive = false;
        if (spawner != null)
        {
            spawner.OnEnemyDestroyed(gameObject);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIController.Instance.ShowGameOver();
        }
    }

    public virtual void UseSkill() { }
}