using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructController : MonoBehaviour
{
    private SceneController sceneController;
    [SerializeField]
    private string sceneName;

    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Managers.GameManager.interactAction += PlayerInteract;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Managers.GameManager.interactAction -= PlayerInteract;
        }
    }

    private void PlayerInteract()
    {
        switch (gameObject.name)
        {
            case "Sign":
                sceneController.SceneChange(sceneName);
                break;
        }
    }
}
