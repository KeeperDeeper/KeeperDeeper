using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartSceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject StartImage;
    [SerializeField]
    private GameObject ClickImage;
    [SerializeField]
    private Image fadeImage;

    private double videoTime;
    private bool active;
    private bool start;
    private bool end;
    private bool plus;

    private void Start()
    {
        ActiveVideo();
        videoTime = ClickImage.GetComponent<VideoPlayer>().length / 4;
    }
    private void Update()
    {
        PressKey();
    }
    public void ActiveVideo()
    {
        active = !active;
        StartImage.SetActive(active);
        ClickImage.SetActive(!active);
    }
    public void PressKey()
    {
        if (Input.anyKeyDown && active && !start)
        {
            start = true;
            ActiveVideo();
            StartCoroutine(StartVideo());
        }
    }
    IEnumerator StartVideo()
    {
        while (!active && start)
        {
            videoTime -= Time.deltaTime;
            if (videoTime <= 0)
            {
                active = true;
                end = true;
                StartCoroutine(FadeIn());
            }
            yield return null;
        }
    }
    IEnumerator FadeIn()
    {
        while (active && end)
        {
            Color color = fadeImage.color;
            color.a += Time.deltaTime;
            fadeImage.color = color;
            if (fadeImage.color.a >= 1)
            {
                active = false;
                SceneManager.LoadScene("MainScene");
            }
            yield return null;
        }
    }
}
