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
        //몬스터 이동
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
            //1.플레이어 산소 감소
            oxygen.DecreaseOxygen(monInfo.monsterInfo.attack);
            //2.충돌시 깜빡거림 효과
            //3. 효과 이후 몬스터 삭제
            Destroy(this.gameObject);
        }
    }
}
