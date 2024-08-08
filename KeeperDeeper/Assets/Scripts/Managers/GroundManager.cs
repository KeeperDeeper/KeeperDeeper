using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GroundManagment
{
    public class GroundManager : MonoBehaviour
    {
        public float pressure = 0; //�� �з�
        public int undergroundFloor;
        [SerializeField]
        private Text pressureText;

        private void Start()
        {
            ResetPressure();
        }

        //���� ī����
        public void CountUnderGroundFloor()
        {
            undergroundFloor += 1;
            IncreasePressure();
        }

        //�� �з� ����
        public void IncreasePressure()
        {
            //5���̻� �������� ���� �� ex)6�� 11��
            if (undergroundFloor % 5 == 1)
            {
                pressure += 1;
            }
            pressureText.text = $"���� �з�: {pressure}";
        }
        //�� �з� �ʱ�ȭ
        public void ResetPressure()
        {
            //��Ұ� �� ��Ұų� ������ �������� ��, �������� �������� ���
            //�з� �ʱ�ȭ
            pressure = 1;
            pressureText.text = $"���� �з�: {pressure}";
        }
    }
}