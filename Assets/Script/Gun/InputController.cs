using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float speed = 5f;
    public void Init()
    {

    }

    void Update()
    {
        float MoveX = 0f;
        float MoveY = 0f;

        if (Input.GetKey(KeyCode.W)) MoveY = 1f;
        if (Input.GetKey(KeyCode.S)) MoveY = -1f;
        if (Input.GetKey(KeyCode.A)) MoveX = -1f;
        if (Input.GetKey(KeyCode.D)) MoveX = 1f;

        Vector3 movement = new Vector3(MoveX, MoveY, 0f).normalized;
        transform.position += movement * speed * Time.deltaTime;
    }
}
