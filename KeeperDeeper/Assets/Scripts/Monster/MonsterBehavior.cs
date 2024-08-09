using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OxygenSystem;

namespace Monster
{
    public class MonsterBehavior : MonoBehaviour
    {
        public MonsterState monState;

        [SerializeField]
        private MonsterInformation monInfo;
        private Oxygen oxygen;

        private Vector2 spawnPoint;
        private BoxCollider2D bodyollider;
        private void Awake()
        {
            bodyollider = GetComponent<BoxCollider2D>();
            spawnPoint = this.transform.position;
        }

        void Start()
        {
            monInfo.InitMonster();
        }

        private void Update()
        {
            if (monState == MonsterState.Move)
            {
                MoveMonster();
            }
            else if (monState == MonsterState.Chase)
            {
                ChaseMonster();
            }
        }
        //���� �̵�
        private void MoveMonster()
        {

        }
        private void ChaseMonster()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                oxygen = FindObjectOfType<Oxygen>();
                CrashPlayer();
            }
        }

        public void TakeDamage(int damage)
        {

        }

        public void CrashPlayer()
        {
            //1.�÷��̾� ��� ����
            oxygen.DecreaseOxygen(monInfo.monsterInfo.attack);
            //2.�浹�� �����Ÿ� ȿ��
            //3. ȿ�� ���� ���� ����
            Destroy(this.gameObject);
        }
    }
}
