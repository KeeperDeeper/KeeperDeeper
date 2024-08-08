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
            floorBlock.gameObject.SetActive(true);
        }
    }
}