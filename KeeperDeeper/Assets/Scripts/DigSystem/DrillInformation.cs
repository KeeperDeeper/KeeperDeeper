using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "DrillInfo", order = 1)]
public class DrillInformation : ScriptableObject
{
    public string drillName; //�帱 �̸�
    public int drillLevel; //�帱 ����
    public int drillPower; //�帱 ��
}