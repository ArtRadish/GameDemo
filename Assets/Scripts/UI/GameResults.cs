using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameResults : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private Button resultsButton;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        if (PlayerPrefs.GetString("GameResults") == "Die")
            textMeshProUGUI.color = Color.red;
        textMeshProUGUI.text = PlayerPrefs.GetString("GameResults");
        resultsButton.onClick.AddListener(GameResultsAction);
    }

    private void GameResultsAction()
    {
        audioSource.Play();
        ScenesManager.Instance.LoadNextScene(0.0f);
    }
}
