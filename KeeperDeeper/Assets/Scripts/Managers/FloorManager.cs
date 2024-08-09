using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FloorManagement
{
    public class FloorManager : MonoBehaviour
    {
        [SerializeField]
        private Floor[] floors;  //모든 층 오브젝트 배열
        [SerializeField]
        private Text floorNumber; //Text 층수 표기

        public int playerFloor = 0; //현재 플레이어 층 수

        private void Start()
        {
            ArrangeFloor();
            ChangeFloorNumber(playerFloor);
        }

        //현재 스테이지의 층을 정렬하고 넘버링
        private void ArrangeFloor()
        {
            floors = FindObjectsOfType<Floor>();//모든 층 찾기
            Array.Reverse(floors);//윗층부터 순서대로 정렬

            //층수 붙이기
            for (int i = 0; i<floors.Length; i++)
            {
                floors[i].GetComponentInChildren<FloorBlock>().floorNum = i+1;
                floors[i].GetComponentInChildren<FloorBlock>().floorManager = this;
            }
        }

        public void ChangeFloorNumber(int floor)
        {
            playerFloor = floor;
            floorNumber.text = $"지하 {playerFloor.ToString()}층";
        }

        [ContextMenu("ResetStage")]
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
    }
}