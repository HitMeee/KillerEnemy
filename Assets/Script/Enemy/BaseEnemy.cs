using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int hp = 3;
    protected bool isAlive = true;

    // ✅ Thêm dòng này để các enemy biết spawner nào sinh ra chúng
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

        // ✅ Khi enemy chết, báo ngược lại cho Spawner biết
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
            Debug.Log("💥 Enemy va chạm Player → Game Over!");
            GameOver();
        }
    }

    void GameOver()
    {
        // Tùy chọn 1: Dừng toàn bộ game
        Time.timeScale = 0f;

        // Tùy chọn 2: Reload lại scene
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Tùy chọn 3: Gọi UI GameOver (nếu bạn có)
        // GameUIController.Instance.ShowGameOver();
    }

    public virtual void UseSkill() { }
}
