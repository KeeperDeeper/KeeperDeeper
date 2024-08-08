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
        private Floor[] floors;  //��� �� ������Ʈ �迭
        [SerializeField]
        private Text floorNumber; //Text ���� ǥ��

        public int playerFloor = 0; //���� �÷��̾� �� ��

        private void Start()
        {
            ArrangeFloor();
            ChangeFloorNumber(playerFloor);
        }

        //���� ���������� ���� �����ϰ� �ѹ���
        private void ArrangeFloor()
        {
            floors = FindObjectsOfType<Floor>();//��� �� ã��
            Array.Reverse(floors);//�������� ������� ����

            //���� ���̱�
            for (int i = 0; i<floors.Length; i++)
            {
                floors[i].GetComponentInChildren<FloorBlock>().floorNum = i+1;
                floors[i].GetComponentInChildren<FloorBlock>().floorManager = this;
            }
        }

        public void ChangeFloorNumber(int floor)
        {
            playerFloor = floor;
            floorNumber.text = $"���� {playerFloor.ToString()}��";
        }

        [ContextMenu("ResetStage")]
        //�������� �ʱ�ȭ��
        public void ResetStageBlock()
        {
            for (int i = 0; i < floors.Length; i++)
            {
                floors[i].ActiveFloorBlock(); //��� ���� �� �ʱ�ȭ
            }
        }
        //���� ���� �ʱ�ȭ �ؾ��� ��
        public void ResetFloor(int floor)
        {
            for (int i = floor; i < floors.Length; i++)
            {
                floors[i].ResetFloor();
            }
        }
    }
}