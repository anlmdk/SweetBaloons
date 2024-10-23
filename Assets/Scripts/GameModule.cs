using CrazyGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModule : MonoBehaviour
{
    public static GameModule Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        CrazySDK.Init(() => { }); // ensure if starting this scene from editor it is initialized
    }

    public void GameplayStart()
    {
        CrazySDK.Game.GameplayStart();
    }

    public void GameplayStop()
    {
        CrazySDK.Game.GameplayStop();
    }

    public void Happytime()
    {
        CrazySDK.Game.HappyTime();
    }
}
