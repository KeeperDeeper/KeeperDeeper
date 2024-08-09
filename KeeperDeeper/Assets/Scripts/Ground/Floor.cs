using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FloorManagement;
using GroundManagment;
using System;
public class Floor : MonoBehaviour
{
    public GameObject blockSlot;
    public FloorBlock floorBlock;

    [SerializeField]
    private Block[] blockObj; //현재 층의 오브젝트 찾기

    private void Start()
    {
        blockObj = blockSlot.GetComponentsInChildren<Block>();
        for (int i = 0; i<blockObj.Length; i++)
        {
            blockObj[i].GetComponent<Block>().floor = this;
        }
    }

    //게임 초기화시 블럭 초기화 시키기
    public void ActiveFloorBlock()
    {
        for (int i = 0; i < blockObj.Length; i++)
        {
            blockObj[i].blockInformation.blockInfo.active = true;
            blockObj[i].gameObject.SetActive(true);
            ResetFloor();
        }
    }
    public void ResetFloor()
    {
        //층수 블럭 초기화 - 게임초기화 및 재도전시 초기화
        //체크포인트에서 시작시 미적용
        floorBlock.gameObject.SetActive(true);
    }
}