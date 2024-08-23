using UnityEngine;
using static Defines;

namespace OxygenSystem
{
    public class Oxygen : MonoBehaviour
    {
        [SerializeField]
        private OxygenInformation oxyInfo;
        [SerializeField]
        private OxygenValue oxyValue;

        private int oxygentankLevel;
        public float maxOxyCapacity;
        public float oxyCapacity;
        private const int consume = 1;//기본 산소 소모량
        private float countTime = 1; //시간 카운트

        public bool check;
        public bool endGame;

        void Start()
        {
            InitOxygenTank();
        }

        void Update()
        {
            //굴착 플레이 시작시
            if (!endGame)//조건문 변경필요
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
                oxyCapacity -= consume * Managers.StageManager.pressure; //산소 차감
                if (oxyCapacity > 0)
                {
                    oxyValue.ChangeOxygenValue(); //Image 산소수치 변경
                }
                else if (oxyCapacity <= 0) //잔여 산소가 없다면
                {
                    PlayerController player = FindObjectOfType<PlayerController>();
                    player.moveStatus = Defines.MoveStatus.Idle;

                    Managers.GameManager.blockInput = true;
                    oxyCapacity = 0; //-값이 안나오도록 0으로 초기화
                    oxyValue.ChangeOxygenValue(); //Image 산소수치 변경
                    Managers.GameManager.EndStage();
                }
                countTime = 1; //시간 초기화
            }
        }
        public void RecoveryOxygen()
        {
            //체크포인트 지날시 산소게이지 50%회복
            if (check)
            {
                check = false;
                oxyCapacity += maxOxyCapacity * 0.5f;
                //최대 산소 저장량을 넘겼을 때
                if (oxyCapacity >= maxOxyCapacity)
                {
                    oxyCapacity = maxOxyCapacity; //최대 산소 저장량으로 변경
                }
            }
            //마을로 복귀시 산소게이지 100% 회복
            else if (endGame)
            {
                oxyCapacity = maxOxyCapacity;
            }
        }

        public void DecreaseOxygen(int damage)
        {
            oxyCapacity -= damage; //몬스터에 의한 산소 차감
        }
    }
}
