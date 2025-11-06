using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BullerManager : MonoBehaviour
{
    public void Init()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="enemy")
        {
            Debug.Log("Hit enemy");
            GamePlayerController.Instance.GameContaint.ScoreController.AddCount();

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
