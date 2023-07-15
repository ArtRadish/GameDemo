using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button QuitButton;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Slider slider;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        StartButton.onClick.AddListener(LoadGameScene);
        QuitButton.onClick.AddListener(QuitGame);
    }

    void LoadGameScene()
    {
        StartCoroutine(LoadScene());
        audioSource.Play();
    }

    void QuitGame()
    {
        Application.Quit();
        audioSource.Play();
        Debug.Log("QuitGame");
    }

    IEnumerator LoadScene()
    {
        text.text = "Loading......";
        yield return new WaitForSeconds(1.0f); //等待规定时间后继续执行

        //AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("main");
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            slider.value = asyncOperation.progress;
            if (asyncOperation.progress >= 0.9f)
            {
                slider.value = 1f;
                text.text = "Loading completed, press the space bar to enter the game";
                if (Input.GetKeyDown(KeyCode.Space))
                    asyncOperation.allowSceneActivation = true;
            }
            yield return null; //暂停协程等待下一帧继续执行
        }
    }
}
