using UnityEngine;

public class BossEnemy : EnemyBase
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireTimer;

    void Start()
    {
        hp = 50;
    }

    void Update()
    {
        if (!isAlive) return;

        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            fireTimer = 0;
            UseSkill();
        }
    }

    public override void UseSkill()
    {
        if (!bulletPrefab) return;

        for (int i = -2; i <= 2; i++)
        {
            Quaternion rot = Quaternion.Euler(0, 0, i * 10);
            GameObject b = Instantiate(bulletPrefab, transform.position, rot);
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            if (rb) rb.AddForce(rot * Vector2.down * 200f);
        }
    }

    protected override void Die()
    {
        Debug.Log("💥 Boss chết!");
        base.Die();
    }
}
