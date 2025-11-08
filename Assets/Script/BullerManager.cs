using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public SpawnGun bulletData; 


    public void Init()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            EnemyBase enemy = collision.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletData.damage);
            }

            GamePlayerController.Instance.GameContaint.ScoreController.AddCount();
            Destroy(gameObject);
        }
    }
}
