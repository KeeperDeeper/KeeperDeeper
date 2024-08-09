using FloorManagement;
using GroundManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBlock : MonoBehaviour
{
    [HideInInspector]
    public FloorManager floorManager;
    public GroundManager groundManager;

    public int floorNum;

    private void Start()
    {
        this.gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (floorManager == null)
            {
                floorManager = FindObjectOfType<FloorManager>();
            }
            if (groundManager == null)
            {
                groundManager = FindObjectOfType<GroundManager>();
            }
            floorManager.ChangeFloorNumber(floorNum); //���� ����
            groundManager.CountUnderGroundFloor(); //���� ���� ī����
            this.gameObject.SetActive(false);
        }
    }
}
