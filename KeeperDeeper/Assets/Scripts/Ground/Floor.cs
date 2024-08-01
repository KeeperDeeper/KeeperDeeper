using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FloorManagement;
using GroundManagment;
public class Floor : MonoBehaviour
{
    //[HideInInspector]
    public FloorManager floorManager;
    public GroundManager groundManager;

    [SerializeField]
    private GameObject[] blockObj; //현재 층의 오브젝트 찾기

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
            floorManager.ChangeFloorNumber(floorNum); //층수 변경
            groundManager.CountUnderGroundFloor(); //지하 층수 카운팅
            this.gameObject.SetActive(false);
        }
    }
    //3.내가 파고 내려온 빈곳체크
}