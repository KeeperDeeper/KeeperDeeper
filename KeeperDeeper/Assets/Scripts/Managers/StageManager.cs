using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StageManagement
{
    public delegate void RestartButton();
    public delegate void StartButton();
    public delegate void ExitButton();

    public class StageManager : MonoBehaviour
    {
        public bool stageSave;
        public int curStageFloor;
        private void Start()
        {
            stageSave = false;
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
            if (stageSave)
            {
                //3.적 - 재시작시 초기화
            }
            else if (!stageSave)
            {

            }
        }
    }
}