using UnityEngine;

public class DuckEnemy : EnemyBase
{
    void Start()
    {
        hp = 3;
    }

    public override void UseSkill()
    {
        if (!isAlive) return;

        Debug.Log("🦆 Duck skill (tạm placeholder)");
        // sau này có thể thêm slow-area hoặc buff
    }
}
