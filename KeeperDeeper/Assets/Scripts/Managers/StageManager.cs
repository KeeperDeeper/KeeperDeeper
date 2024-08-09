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
            //�������� �÷��� ������ ����
            stageSave = true;

            curStageFloor = curFloor; //���� üũ����Ʈ �� ����
            //1.�������� ����
            //2.������ ��� ���� ����
        }
        public void LoadStageData()
        {
            //üũ����Ʈ ����
            if (stageSave)
            {
                groundManager.ChangePressure(); //üũ����Ʈ ��ġ �з� �� �޾ƿ���
                floorManager.ChangeFloorNumber(curStageFloor); //üũ����Ʈ �� �ҷ�����
                floorManager.ResetFloor(curStageFloor); //üũ����Ʈ ��ġ���� ���� �� �ʱ�ȭ ��Ű��
            }
            //üũ����Ʈ���� �������� ���� ��
            else if (!stageSave)
            {
                groundManager.ChangePressure(); //1�� �з����� ����
                if (restart)
                {
                    floorManager.ResetFloor(0);//���� �� ��� �ʱ�ȭ
                }
                else if (!restart)
                {
                    floorManager.ResetStageBlock(); //��� �� �ʱ�ȭ
                }
                floorManager.ChangeFloorNumber(0);
            }
            //3.�� - ����۽� �ʱ�ȭ
        }
    }
}