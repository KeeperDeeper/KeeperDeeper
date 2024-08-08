using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FloorManagement;
using GroundManagment;

namespace StageManagement
{
    public class StageManager : MonoBehaviour
    {
        [SerializeField]
        private FloorManager floorManager;
        [SerializeField]
        private GroundManager groundManager;

        public bool stageSave;
        public bool restart;
        public int curStageFloor;

        private void Start()
        {
            groundManager.ResetPressure();
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
                groundManager.ChangePressure(); //체크포인트 위치 압력 값 받아오기
                floorManager.ChangeFloorNumber(curStageFloor); //체크포인트 층 불러오기
                floorManager.ResetFloor(curStageFloor); //체크포인트 위치부터 층수 블럭 초기화 시키기
            }
            //체크포인트에서 시작하지 않을 때
            else if (!stageSave)
            {
                groundManager.ChangePressure(); //1층 압력으로 리셋
                if (restart)
                {
                    floorManager.ResetFloor(0);//층수 블럭 모두 초기화
                }
                else if (!restart)
                {
                    floorManager.ResetStageBlock(); //모든 블럭 초기화
                }
                floorManager.ChangeFloorNumber(0);
            }
            //3.적 - 재시작시 초기화
        }
    }
}