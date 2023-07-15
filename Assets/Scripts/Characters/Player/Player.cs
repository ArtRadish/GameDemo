using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IGameOver
{
    const string kDie = "Die";
    [SerializeField] private float dieHight = -10.0f;

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
        if (blood.GetSliderValue() <= 0 || transform.position.y <= dieHight)
        {
            PlayerPrefs.SetString("GameResults", "Die");
            //ScenesManager.Instance.GameResults = "Die";
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
        else if(transform.position.y <= dieHight)
        {
            GetComponent<Animator>().SetTrigger(kDie);
            float y = transform.position.y;
            y = y <= dieHight ? dieHight : y;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
            blood.CurBlood = 0.0f;
        }

        GetComponent<PlayerInput>().enabled = false;
    }
}
