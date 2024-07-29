using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OxygenSystem;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private Oxygen oxygen;

    private void Start()
    {
        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.oxygen = FindObjectOfType<Oxygen>();
            oxygen.check = true;
            oxygen.RecoveryOxygen();
            this.gameObject.SetActive(false);
        }
    }
}
