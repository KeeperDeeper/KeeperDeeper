using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCSO", menuName = "ScriptableObject/NPCSO", order = int.MinValue)]
public class NPCSO : ScriptableObject
{
    public int npcId;
    public int likeability;     // È£°¨µµ
    public string npcName;
    public List<int> dialogueIdList;
    public List<int> dialogueRangeByLike;
}
