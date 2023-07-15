using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [HideInInspector] public List<IGameOver> gameOvers = new List<IGameOver>();
    [HideInInspector] public bool isGameOver;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
    }

    private void Update()
    {
        FindIsGameOver();
        GameOver();
    }

    private void FindIsGameOver()
    {
        for (int i = 0; i < gameOvers.Count; i++)
        {
            if(gameOvers[i].TriggerGameOver())
            {
                isGameOver = true;
                break;
            }
        }
    }

    private void GameOver()
    {
        if (!isGameOver)
            return;

        for(int i=0;i< gameOvers.Count;i++)
        {
            gameOvers[i].GameOverAction();
        }
    }
}
