using UnityEngine;

public class BirdEnemy : EnemyBase
{
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    private float fireTimer;

    void Start()
    {
        hp = 2;
    }

    void Update()
    {
       
    }

    public override void UseSkill()
    {
        if (bulletPrefab)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
