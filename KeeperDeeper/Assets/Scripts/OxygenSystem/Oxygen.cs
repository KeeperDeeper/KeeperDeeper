using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GroundManagment;

namespace OxygenSystem
{
    public class Oxygen : MonoBehaviour
    {
        [SerializeField]
        private OxygenInformation oxyInfo;
        [SerializeField]
        private GroundManager groundManager;
        [SerializeField]
        private OxygenValue oxyValue;

        private int oxygentankLevel;
        public float maxOxyCapacity;
        public float oxyCapacity;
        private const int consume = 1;//�⺻ ��� �Ҹ�
        private float countTime = 1; //�ð� ī��Ʈ

        private void Awake()
        {
            
        }
        void Start()
        {
            InitOxygenTank();
        }

        void Update()
        {
            //���� �÷��� ���۽�
            if (true)//���ǹ� �����ʿ�
            {
                ConsumptionOxygen();
            }
        }

        public void InitOxygenTank()
        {
            oxygentankLevel = oxyInfo.oxygentankLv;
            maxOxyCapacity = oxyInfo.oxygenCapacity;
            oxyCapacity = maxOxyCapacity;
        }
        public void ConsumptionOxygen()
        {
            countTime -= Time.deltaTime;
            //1�ʰ� ������
            if (countTime <= 0)
            {
                oxyCapacity -= consume * groundManager.pressure; //��� ����
                if (oxyCapacity > 0)
                {
                    oxyValue.ChangeOxygenValue(); //Image ��Ҽ�ġ ����
                }
                else if (oxyCapacity <= 0) //�ܿ� ��Ұ� ���ٸ�
                {
                    oxyCapacity = 0; //-���� �ȳ������� 0���� �ʱ�ȭ
                    oxyValue.ChangeOxygenValue(); //Image ��Ҽ�ġ ����
                    groundManager.ResetPressure(); //�з� �ʱ�ȭ
                    //������ �÷��̾� ����
                    //�����÷��� ���� Update������ ���ư��� �ʵ��� falseó�� ���ֱ�
                }
                countTime = 1; //�ð� �ʱ�ȭ
            }
        }
        public void RecoveryOxygen()
        {
            //üũ����Ʈ ������ ��Ұ����� 50%ȸ��
            oxyCapacity += maxOxyCapacity * 0.5f;
            //������ ���ͽ� ��Ұ����� 100% ȸ��
            oxyCapacity = maxOxyCapacity;
        }
    }
}
