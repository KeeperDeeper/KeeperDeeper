using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private GameObject resultImage;
    [SerializeField]
    private Text result;
    [SerializeField]
    private string sceneName;

    private void Start()
    {
        resultImage.SetActive(false);
    }

    public void EndGame(bool clear)
    {
        resultImage.SetActive(true);
        if (clear)
        {
            result.text = "구출 성공!";
        }
        else if (!clear)
        {
            result.text = "구출 실패...";
        }
    }
    public void MoveVillage()
    {
        resultImage.SetActive(false);
        SceneController scene = FindObjectOfType<SceneController>();
        scene.SceneChange(sceneName);
    }
}
