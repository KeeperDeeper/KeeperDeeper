using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BlockInfo
{
    public enum BlockStrength { Lv0, Lv1, Lv2,  Lv3 }; //�� �з�
    public float blockLife; //�������ϴ� �ð�
    public bool active;
}

[CreateAssetMenu(fileName = "", menuName = "Block", order = 0)]
public class BlockInformation : ScriptableObject
{
    public Sprite blockImg;
    public BlockInfo blockInfo;
    public BlockInfo.BlockStrength blockStr;
    public float diggingTime;

    //�� ���� �ʱ�ȭ
    public void Init()
    {
        diggingTime = blockInfo.blockLife;

        for (int i = 0; i < Enum.GetValues(typeof(BlockInfo.BlockStrength)).Length; i++)
        {
            //��� ° ��ġ���� ã��
            if ((int)blockStr == i)
            {
                diggingTime = i + 1;
            }
        }
    }
}