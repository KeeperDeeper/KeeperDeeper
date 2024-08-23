using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;

    private void OnLevelWasLoaded(int level)
    {
        StartCoroutine(FadeOut());
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SceneChange(string sceneName)
    {
        StartCoroutine(FadeIn(sceneName));
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeIn(string sceneName)
    {
        Color aColor = fadeImage.color;
        aColor.a = 0;
        fadeImage.color = aColor;

        while (fadeImage.color.a > 1)
        {
            Color color = fadeImage.color;
            color.a += Time.deltaTime;
            fadeImage.color = color;
            if (fadeImage.color.a > 1)
            {
                LoadScene(sceneName);
            }
            yield return null;
        }
    }
    IEnumerator FadeOut()
    {
        Color aColor = fadeImage.color;
        aColor.a = 1;
        fadeImage.color = aColor;

        while (fadeImage.color.a <  0)
        {
            Color color = fadeImage.color;
            color.a += Time.deltaTime;
            fadeImage.color = color;
            yield return null;
        }
    }
}