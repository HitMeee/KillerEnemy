using UnityEngine;

public class SpawnGun : MonoBehaviour
{
    public float speed = 0.1f;      
    public float lifeTime = 3f;     

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
