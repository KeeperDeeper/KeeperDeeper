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
    private Block[] blockObj; //���� ���� ������Ʈ ã��

    private void Start()
    {
        blockObj = blockSlot.GetComponentsInChildren<Block>();
        for (int i = 0; i<blockObj.Length; i++)
        {
            blockObj[i].GetComponent<Block>().floor = this;
        }
    }

    //���� �ʱ�ȭ�� �� �ʱ�ȭ ��Ű��
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