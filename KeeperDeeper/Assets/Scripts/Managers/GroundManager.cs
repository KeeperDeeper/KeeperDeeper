using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroundManagment
{
    public class GroundManager : MonoBehaviour
    {
        public float pressure = 1; //땅 압력
        public int countGround;

        //층수 카운팅
        public void CountUnderGroundFloor()
        {
            countGround += 1;
        }

        //땅 압력 증가
        public void IncreasePressure()
        {
            //5층이상 내려가게 됐을 때 ex)6층 11층
            if (countGround%5 == 0)
            {
                pressure += 1;
            }
        }
        //땅 압력 초기화
        public void ResetPressure()
        {
            //산소가 다 닳았거나 최하층에 도착했을 경우
            //압력 초기화
            pressure = 1;
        }
    }
}