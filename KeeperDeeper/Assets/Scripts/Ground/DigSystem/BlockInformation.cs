using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BlockInfo
{
    public enum BlockStrength { Lv0, Lv1, Lv2,  Lv3 }; //블럭 분류
    public float blockLife; //굴착해하는 시간
    public bool active;
}

[CreateAssetMenu(fileName = "", menuName = "Block", order = 0)]
public class BlockInformation : ScriptableObject
{
    public Sprite blockImg;
    public BlockInfo blockInfo;
    public BlockInfo.BlockStrength blockStr;
    public float diggingTime;

    //블럭 정보 초기화
    public void Init()
    {
        diggingTime = blockInfo.blockLife;

        for (int i = 0; i < Enum.GetValues(typeof(BlockInfo.BlockStrength)).Length; i++)
        {
            //몇번 째 위치인지 찾기
            if ((int)blockStr == i)
            {
                diggingTime = i + 1;
            }
        }
    }
}