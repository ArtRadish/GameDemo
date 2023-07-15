using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour, IGameOver
{
    const string kDie = "Die";

    private void Start()
    {
        AddGameController();
    }

    private void Update()
    {

    }

    public void AddGameController()
    {
        GameController.Instance.gameOvers.Add(this);
    }

    public bool TriggerGameOver()
    {
        Blood blood = GetComponent<Blood>();
        if (blood.GetSliderValue() <= 0)
        {
            PlayerPrefs.SetString("GameResults", "Win");
            //ScenesManager.Instance.GameResults = "Win";
            return true;
        }
        return false;
    }

    public void GameOverAction()
    {
        Blood blood = GetComponent<Blood>();
        if (blood.GetSliderValue() <= 0)
        {
            GetComponent<Animator>().SetTrigger(kDie);
        }

        MonsterSkillManager.Instance.enabled = false;
        GetComponent<BombSkill>().enabled = false;
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject monster in monsters)
        { Destroy(monster); }
    }
}
