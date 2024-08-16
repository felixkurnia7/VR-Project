using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuScreen;
    [SerializeField]
    private GameObject communicationScreen;
    [SerializeField]
    private GameObject leadershipsScreen;
    [SerializeField]
    private GameObject LoadingScreen;
    [SerializeField]
    private Slider loadingSlider;

    [SerializeField]
    private float timer;

    [SerializeField]
    private FadeCanvas _fade;

    public void GoToSceneAsync(string sceneName)
    {
        menuScreen.SetActive(false);
        communicationScreen.SetActive(false);
        leadershipsScreen.SetActive(false);
        LoadingScreen.SetActive(true);

        StartCoroutine(GoToSceneAsyncRoutine(sceneName));
    }

    //public void GoToLoadingScene(string sceneToGo)
    //{
    //    StartCoroutine(GoToLoadingSceneRoutine(sceneToGo));
    //}

    IEnumerator GoToSceneAsyncRoutine(string sceneName)
    {
        _fade.StartFadeIn();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        float temp = 0f;

        while (!operation.isDone && temp <= timer)
        {
            float progressiveValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progressiveValue;
            temp += Time.deltaTime;
            yield return null;
        }

    }

    //IEnumerator GoToLoadingSceneRoutine(string sceneToGo)
    //{
    //    _loading.sceneToGo = sceneToGo;

    //    AsyncOperation operation = SceneManager.LoadSceneAsync("Loading");

    //    while (!operation.isDone)
    //    {
    //        yield return null;
    //    }
    //}
}
