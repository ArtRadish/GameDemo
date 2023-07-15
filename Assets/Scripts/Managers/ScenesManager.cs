using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : Singleton<ScenesManager>
{
    //[HideInInspector] public string GameResults;

    protected override void Awake()
    {
        base.Awake();
        //DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }


    public void LoadIndexScene(int index, float waitTime)
    {
        index = index >= SceneManager.sceneCountInBuildSettings ? 0 : index;
        StartCoroutine(LoadScene(index, waitTime));
    }

    public void LoadNextScene(float waitTime)
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        index = index % SceneManager.sceneCountInBuildSettings;
        StartCoroutine(LoadScene(index, waitTime));
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QuitGame");
    }

    IEnumerator LoadScene(int index, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        yield return null;
    }


}
