using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OxygenSystem;
using UnityEngine.UI;
using UnityEngine.AI;

namespace Monster
{
    public class MonsterBehavior : MonoBehaviour
    {
        public MonsterState monState;
        public MonsterCombat monCombat;
        public MonsterMove monMove;

        public MonsterInformation monInfo;
        private Oxygen oxygen;

        private Rigidbody2D rigid;
        private BoxCollider2D bodyollider;
        private SpriteRenderer spriteRenderer;
        private Animator animator;

        private Image monSprite;
        private Transform target;

        public float blinkTime;
        public float moveTime = 1;
        public int nextMove;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            bodyollider = GetComponent<BoxCollider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

            monSprite = GetComponent<Image>();
        }

        void Start()
        {
            monInfo.InitMonster();

            monState = MonsterState.Wait;
            monCombat = MonsterCombat.None;
            MovePattern(); //첫 행동패턴 설정

            transform.GetComponentInChildren<PlayerScanner>().SetScannerSize();
        }

        private void Update()
        {
            if (monState == MonsterState.Move)
            {
                Timer();
            }
        }
        private void FixedUpdate()
        {
            if (monState == MonsterState.Move && monCombat != MonsterCombat.Damage)
            {
                MoveMonster();
            }
            else if (monState == MonsterState.Chase)
            {
                ChasePlayer();
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //플레이어와 충돌 했다면
            if (collision.gameObject.CompareTag("Player"))
            {
                oxygen = FindObjectOfType<Oxygen>();
                CrashPlayer();
            }
            //벽에 부딪혔을 때 방향전환
            else if (collision.gameObject.CompareTag("Wall"))
            {
                MovePattern();
            }
        }
        private void Timer()
        {
            moveTime -= Time.deltaTime;
            if (moveTime <= 0)
            {
                MovePattern();
                moveTime = 1;
            }
        }
        public void MovePattern()
        {
            nextMove = Random.Range(-1, 2);
            if (nextMove == -1)
            {
                monMove = MonsterMove.Left;
            }
            else if (nextMove == 0)
            {
                monMove = MonsterMove.Stop;
            }
            else if (nextMove == 1)
            {
                monMove = MonsterMove.Right;
            }

            monState = MonsterState.Move;
        }
        //몬스터 이동
        private void MoveMonster()
        {
            if (monMove == MonsterMove.Left)
            {
                //animator.SetInteger("WalkLeft", -1);
            }
            else if (monMove == MonsterMove.Right)
            {
                //animator.SetInteger("WalkRight", 1);
            }
            else if (monMove == MonsterMove.Stop)
            {
                //animator.SetInt("WalkRight", 0);
            }
            rigid.velocity = new Vector2(nextMove * monInfo.monsterInfo.speed, rigid.velocity.y);
        }
        //플레이어 추격
        private void ChasePlayer()
        {
            rigid.velocity = new Vector2();
        }

        public void TakeDamage(int damage)
        {
            KnockBack(50f, 20f); //넉백
            monInfo.monsterInfo.hp -= damage;
            monCombat = MonsterCombat.Damage;
            BlinkMonster(1); //깜빡이는 효과

            if (monInfo.monsterInfo.hp > 0)
            {
                
            }
            else if (monInfo.monsterInfo.hp <= 0)
            {
                monInfo.monsterInfo.hp = 0;
                monState = MonsterState.Die;
                //사망 이펙트 추가 //펑 터짐
                Destroy(this.gameObject);
            }
        }

        public void CrashPlayer()
        {
            //1.플레이어 산소 감소
            oxygen.DecreaseOxygen(monInfo.monsterInfo.attack);

            //몬스터 사망시 효과
            BlinkMonster(2);
            //3. 효과 이후 몬스터 삭제
            Destroy(this.gameObject);
        }
        //피격시 깜빡거림 효과
        public void BlinkMonster(int blinkCount)
        {
            monCombat = MonsterCombat.None;
        }
        //넉백 효과
        public void KnockBack(float xPower, float yPower)
        {
            rigid.velocity -= new Vector2(-transform.forward.x * xPower, rigid.velocity.y + yPower);
        }
    }
}