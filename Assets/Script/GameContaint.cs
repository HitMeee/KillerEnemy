using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContaint : MonoBehaviour
{
    public InputController inputController;
    public ScoreController ScoreController;
    public EnemySpawner EnemySpawner;
    public PlayerController PlayerController;

    public void Init()
    {
        inputController.Init();
        ScoreController.Init();
        EnemySpawner.Init();
        PlayerController.Init();
    }
}
