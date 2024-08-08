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
            //�������� �÷��� ������ ����
            stageSave = true;

            curStageFloor = curFloor; //���� üũ����Ʈ �� ����
            //1.�������� ����
            //2.������ ��� ���� ����
        }
        public void LoadStageData()
        {
            if (stageSave)
            {
                //3.�� - ����۽� �ʱ�ȭ
            }
            else if (!stageSave)
            {

            }
        }
    }
}