using UnityEngine;
using UnityEngine.UI;
using System;

namespace StageManagement
{
    public class StageManager : IManagers
    {
        public bool stageSave;
        public bool restart;
        public int curStageFloor;

        public int pressure = 1; //땅 압력
        public int undergroundFloor;
        [SerializeField]
        private Text pressureText;

        [SerializeField]
        private Floor[] floors;  //모든 층 오브젝트 배열
        [SerializeField]
        private Text floorText; //Text 층수 표기

        public int playerFloor = 0; //현재 플레이어 층 수

        public void Init()
        {
            pressureText = GameObject.Find("CurrentPressure").GetComponent<Text>();
            floorText = GameObject.Find("CurrentFloor").GetComponent<Text>();
            ResetPressure();
            ArrangeFloor();
            ChangeFloorNumber(playerFloor);
        }

        public void SaveStageData(int curFloor)
        {
            //스테이지 플레이 데이터 저장
            stageSave = true;

            curStageFloor = curFloor; //현재 체크포인트 층 저장
            //1.굴착상태 저장
            //2.아이템 드랍 상태 저장
        }

        public void LoadStageData()
        {
            //체크포인트 시작
            if (stageSave)
            {
                ChangePressure(); //체크포인트 위치 압력 값 받아오기
                ChangeFloorNumber(curStageFloor); //체크포인트 층 불러오기
                ResetFloor(curStageFloor); //체크포인트 위치부터 층수 블럭 초기화 시키기
            }
            //체크포인트에서 시작하지 않을 때
            else if (!stageSave)
            {
                ChangePressure(); //1층 압력으로 리셋
                if (restart)
                {
                    ResetFloor(0);//층수 블럭 모두 초기화
                }
                else if (!restart)
                {
                    ResetStageBlock(); //모든 블럭 초기화
                }
                ChangeFloorNumber(0);
            }
            //3.적 - 재시작시 초기화
        }

        #region 전 GroundManager
        //층수 카운팅
        public void CountUnderGroundFloor()
        {
            undergroundFloor += 1;
            ChangePressure();
        }

        //땅 압력 증가
        public void ChangePressure()
        {
            //5층이상 내려가게 됐을 때 ex)6층 11층
            pressure = undergroundFloor / 5 + 1;
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
        #endregion

        #region 전 FloorManager
        //현재 스테이지의 층을 정렬하고 넘버링
        private void ArrangeFloor()
        {
            floors = UnityEngine.Object.FindObjectsOfType<Floor>();//모든 층 찾기
            Array.Reverse(floors);//윗층부터 순서대로 정렬

            //층수 붙이기
            for (int i = 0; i < floors.Length; i++)
            {
                floors[i].GetComponentInChildren<FloorBlock>().floorNum = i + 1;
            }
        }

        public void ChangeFloorNumber(int floor)
        {
            playerFloor = floor;
            floorText.text = $"지하 {playerFloor.ToString()}층";
        }

        //스테이지 초기화시
        public void ResetStageBlock()
        {
            for (int i = 0; i < floors.Length; i++)
            {
                floors[i].ActiveFloorBlock(); //모든 층의 블럭 초기화
            }
        }
        //층수 블럭만 초기화 해야할 때
        public void ResetFloor(int floor)
        {
            for (int i = floor; i < floors.Length; i++)
            {
                floors[i].ResetFloor();
            }
        }
        #endregion
    }
}