using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GroundManagment;

namespace OxygenSystem
{
    public class Oxygen : MonoBehaviour
    {
        [SerializeField]
        private OxygenInformation oxyInfo;
        [SerializeField]
        private GroundManager groundManager;
        [SerializeField]
        private OxygenValue oxyValue;

        private int oxygentankLevel;
        public float maxOxyCapacity;
        public float oxyCapacity;
        private const int consume = 1;//기본 산소 소모량
        private float countTime = 1; //시간 카운트

        private void Awake()
        {
            
        }
        void Start()
        {
            InitOxygenTank();
        }

        void Update()
        {
            //굴착 플레이 시작시
            if (true)//조건문 변경필요
            {
                ConsumptionOxygen();
            }
        }

        public void InitOxygenTank()
        {
            oxygentankLevel = oxyInfo.oxygentankLv;
            maxOxyCapacity = oxyInfo.oxygenCapacity;
            oxyCapacity = maxOxyCapacity;
        }
        public void ConsumptionOxygen()
        {
            countTime -= Time.deltaTime;
            //1초가 지나면
            if (countTime <= 0)
            {
                oxyCapacity -= consume * groundManager.pressure; //산소 차감
                if (oxyCapacity > 0)
                {
                    oxyValue.ChangeOxygenValue(); //Image 산소수치 변경
                }
                else if (oxyCapacity <= 0) //잔여 산소가 없다면
                {
                    oxyCapacity = 0; //-값이 안나오도록 0으로 초기화
                    oxyValue.ChangeOxygenValue(); //Image 산소수치 변경
                    groundManager.ResetPressure(); //압력 초기화
                    //마을로 플레이어 복귀
                    //굴착플레이 종료 Update문에서 돌아가지 않도록 false처리 해주기
                }
                countTime = 1; //시간 초기화
            }
        }
        public void RecoveryOxygen()
        {
            //체크포인트 지날시 산소게이지 50%회복
            oxyCapacity += maxOxyCapacity * 0.5f;
            //마을로 복귀시 산소게이지 100% 회복
            oxyCapacity = maxOxyCapacity;
        }
    }
}
