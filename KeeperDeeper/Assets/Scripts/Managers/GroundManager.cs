using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GroundManagment
{
    public class GroundManager : MonoBehaviour
    {
        public float pressure = 0; //땅 압력
        public int undergroundFloor;
        [SerializeField]
        private Text pressureText;

        private void Start()
        {
            ResetPressure();
        }

        //층수 카운팅
        public void CountUnderGroundFloor()
        {
            undergroundFloor += 1;
            IncreasePressure();
        }

        //땅 압력 증가
        public void IncreasePressure()
        {
            //5층이상 내려가게 됐을 때 ex)6층 11층
            if (undergroundFloor % 5 == 1)
            {
                pressure += 1;
            }
            pressureText.text = $"현재 압력: {pressure}";
        }
        //땅 압력 초기화
        public void ResetPressure()
        {
            //산소가 다 닳았거나 게임을 시작했을 때, 최하층에 도착했을 경우
            //압력 초기화
            pressure = 1;
            pressureText.text = $"현재 압력: {pressure}";
        }
    }
}