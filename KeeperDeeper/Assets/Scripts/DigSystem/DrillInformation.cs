using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "DrillInfo", order = 1)]
public class DrillInformation : ScriptableObject
{
    public string drillName; //드릴 이름
    public int drillLevel; //드릴 레벨
    public int drillPower; //드릴 힘
}