using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gunPrefab;

    public void Init()
    {
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateGun();
        }
    }
    public void CreateGun()
    {
        GameObject gun = Instantiate(gunPrefab, transform.position, Quaternion.identity);
    }

}
