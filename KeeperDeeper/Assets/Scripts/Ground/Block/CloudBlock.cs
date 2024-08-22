using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBlock : MonoBehaviour
{
    public bool active;

    private void Start()
    {
        active = true;
        ActiveCloud();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = false;
            ActiveCloud();
        }
    }
    private void ActiveCloud()
    {
        gameObject.SetActive(active);
    }
}