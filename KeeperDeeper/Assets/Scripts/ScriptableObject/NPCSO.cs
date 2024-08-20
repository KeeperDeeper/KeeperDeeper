using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObject/NPCSO", order = int.MinValue)]
public class NPCSO : ScriptableObject
{
    public int npcId;
    public string npcName;
    public List<int> dialogueIdList;
}
