using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject StartImage;
    [SerializeField]
    private GameObject ClickImage;
    [SerializeField]
    private Image fadeImage;

    private bool active;

    private void Start()
    {
        ActiveVideo();
    }
    public void ActiveVideo()
    {
        active = !active;
        StartImage.SetActive(active);
        ClickImage.SetActive(!active);
    }
    private void FadeOut()
    {
        Color color = fadeImage.color;
        while (!active)
        {
            color.a -= Time.deltaTime;
            if (color.a <= 0)
            {
                active = false;
            }
        }
    }
}
