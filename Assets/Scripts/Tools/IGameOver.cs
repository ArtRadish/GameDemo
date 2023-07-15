using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameOver
{
    public void AddGameController();
    public bool TriggerGameOver();
    public void GameOverAction();
}
