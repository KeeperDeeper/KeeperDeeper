using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어가 굴착시 상용할 Script
//드릴오브젝트에 넣을 Script
namespace DrillObject
{
    public class Drill : MonoBehaviour
    {
        public DrillInformation drillInformation;
        
        public string drillName; //드릴 이름
        public int drillLv;//드릴 레벨
        public int drillPo;//드릴 힘

        void Start()
        {
            ChangeDrillInformation();
        }

        //드릴 정보 변경
        public void ChangeDrillInformation()
        {
            drillName = drillInformation.drillName;
            drillLv = drillInformation.drillLevel;
            drillPo = drillInformation.drillPower;
        }
    }
}