using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroundManagment
{
    public class GroundManager : MonoBehaviour
    {
        public float pressure = 1; //�� �з�
        public int countGround;

        //���� ī����
        public void CountUnderGroundFloor()
        {
            countGround += 1;
        }

        //�� �з� ����
        public void IncreasePressure()
        {
            //5���̻� �������� ���� �� ex)6�� 11��
            if (countGround%5 == 0)
            {
                pressure += 1;
            }
        }
        //�� �з� �ʱ�ȭ
        public void ResetPressure()
        {
            //��Ұ� �� ��Ұų� �������� �������� ���
            //�з� �ʱ�ȭ
            pressure = 1;
        }
    }
}