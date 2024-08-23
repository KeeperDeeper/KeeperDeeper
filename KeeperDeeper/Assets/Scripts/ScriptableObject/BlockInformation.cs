using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockStrength { Lv1, Lv2,  Lv3, Lv4, Wall }; //블럭 분류

public struct BlockInfo
{
    public float blockLife; //굴착해하는 시간
    public bool active;
}

[CreateAssetMenu(fileName = "", menuName = "BlockSO", order = 0)]
public class BlockInformation : ScriptableObject
{
    public BlockInfo blockInfo;
    public BlockStrength blockStr;
    public float diggingTime;
    public Sprite originSprite;
    public Sprite crackSprite;

    //블럭 정보 초기화
    public void Init()
    {

        for (int i = 0; i < Enum.GetValues(typeof(BlockStrength)).Length; i++)
        {
            //몇번 째 위치인지 찾기
            if ((int)blockStr == i)
            {
                diggingTime = (i + 1) * 2 - 1;
            }
        }
        blockInfo.blockLife = diggingTime;
    }
}