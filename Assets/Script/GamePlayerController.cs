using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerController : MonoBehaviour
{ 
    public static GamePlayerController Instance;

    public GameContaint GameContaint;
    public GameScene GameScene;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GameScene.Init();
        GameContaint.Init();
    }

    
}
