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
                Debug.Log(i);
                floors[i].GetComponent<Floor>().floorNum = i+1;
                floors[i].GetComponent<Floor>().floorManager = this;
            }
        }

        public void ChangeFloorNumber(int floor)
        {
            playerFloor = floor;
            floorNumber.text = $"���� {playerFloor.ToString()}��";
        }
    }
}
