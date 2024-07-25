using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾ ������ ����� Script
//�帱������Ʈ�� ���� Script
namespace DrillObject
{
    public class Drill : MonoBehaviour
    {
        public DrillInformation drillInformation;
        
        public string drillName; //�帱 �̸�
        public int drillLv;//�帱 ����
        public int drillPo;//�帱 ��

        void Start()
        {
            ChangeDrillInformation();
        }

        //�帱 ���� ����
        public void ChangeDrillInformation()
        {
            drillName = drillInformation.drillName;
            drillLv = drillInformation.drillLevel;
            drillPo = drillInformation.drillPower;
        }
    }
}