using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GroundManagment
{
    public class GroundManager : MonoBehaviour
    {
        public int pressure = 1; //�� �з�
        public int undergroundFloor;
        [SerializeField]
        private Text pressureText;

        //���� ī����
        public void CountUnderGroundFloor()
        {
            undergroundFloor += 1;
            ChangePressure();
        }

        //�� �з� ����
        public void ChangePressure()
        {
            //5���̻� �������� ���� �� ex)6�� 11��
            pressure = undergroundFloor / 5 + 1;
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