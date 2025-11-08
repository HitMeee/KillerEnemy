using UnityEngine;

public class SpawnGun : MonoBehaviour
{
    public float speed;
    public float timeToLive;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;    
    }
}
