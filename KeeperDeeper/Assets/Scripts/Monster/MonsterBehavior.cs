using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OxygenSystem;
using UnityEngine.UI;

namespace Monster
{
    public class MonsterBehavior : MonoBehaviour
    {
        public MonsterState monState;
        public MonsterCombat monCombat;
        public MonsterMove monMove;

        public MonsterInformation monInfo;
        private Oxygen oxygen;

        protected Rigidbody2D rigid;
        private BoxCollider2D bodyollider;
        protected Animator animator;
        [SerializeField]
        private SpriteRenderer monsterRenderer;
        [SerializeField]
        private SpriteRenderer dieEffect;

        public Transform target;
        protected float direction;

        public float blinkTime;
        public float moveTime = 1;
        public int nextMove;
        protected bool move;
        protected float playerRange;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            bodyollider = GetComponent<BoxCollider2D>();
            monsterRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        protected virtual void Start()
        {
            monInfo.InitMonster();

            monState = MonsterState.Wait;
            monCombat = MonsterCombat.None;
            MovePattern(); //첫 행동패턴 설정

            transform.GetComponentInChildren<PlayerScanner>().SetScannerSize();
        }

        protected virtual void Update()
        {
            if (monState == MonsterState.Move && monInfo.monKind != MonsterKind.Dig)
            {
                Timer();
            }
        }
        protected virtual void FixedUpdate()
        {
            if (monState == MonsterState.Move && monInfo.monKind != MonsterKind.Dig)
            {
                MoveMonster();
            }
            else if (monState == MonsterState.Chase)
            {
                ChasePlayer();
            }
        }
        protected virtual void OnCollisionEnter2D(Collision2D collision)
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
                move = true;
            }
            else if (nextMove == 0)
            {
                monMove = MonsterMove.Stop;
                move = false;
            }
            else if (nextMove == 1)
            {
                monMove = MonsterMove.Right;
                move = true;
            }

            monState = MonsterState.Move;
        }
        //몬스터 이동
        private void MoveMonster()
        {
            animator.SetBool("Move", move);
            if (monMove == MonsterMove.Left)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (monMove == MonsterMove.Right)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                
            }
            rigid.velocity = new Vector2(nextMove * monInfo.monsterInfo.speed, rigid.velocity.y);
        }
        protected virtual void ChasePlayer()
        {
            LookRotate(); //플레이어 바라보기

            playerRange = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2)); //플레이어와 거리

            if (playerRange > monInfo.monsterInfo.attackRange && monInfo.monKind != MonsterKind.Dig) //공격범위보다 멀때
            {
                rigid.velocity = new Vector2(direction * monInfo.monsterInfo.speed, rigid.velocity.y);
            }
            else if(playerRange <=  monInfo.monsterInfo.attackRange)
            {
                //범위에 들어오면 힘 없애기;
                rigid.velocity = Vector2.zero;
            }
        }
        private void LookRotate()
        {
            if (monCombat == MonsterCombat.None)
            {
                direction = target.position.x - transform.position.x; //캐릭터가 있는 방향 X축 이용
                direction = direction > 0 ? 1 : -1; //좌우방향

                if (direction == -1)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (direction == 1)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {

                }
            }
            else
            {

            }
            //스캐너 회전각 고정
            transform.GetChild(0).GetComponent<PlayerScanner>().transform.eulerAngles = new Vector3(0, 0, 0);
        }

        public void TakeDamage(int damage)
        {
            KnockBack(100, 20); //넉백
            monInfo.monsterInfo.hp -= damage;
            StartCoroutine(BlinkMonster(1, 2)); //깜빡이는 효과

            if (monInfo.monsterInfo.hp > 0)
            {
                
            }
            else //몬스터의 체력이 0보다 작거나 같을 때
            {
                monInfo.monsterInfo.hp = 0;
                Die();
            }
        }

        public void CrashPlayer()
        {
            //1.플레이어 산소 감소
            oxygen.DecreaseOxygen(monInfo.monsterInfo.attack);
            Die();
        }

        //피격시 깜빡거림 효과
        IEnumerator BlinkMonster(float blinkTime, int blinkCount)
        {
            float time = blinkTime;
            while (time > 0)
            {
                time -= Time.deltaTime;

                monsterRenderer.color = Color.red;
                yield return new WaitForSeconds(blinkTime / blinkCount / 2);

                time -= blinkTime / blinkCount / 2;
                monsterRenderer.color = new Color(1, 1, 1);
                yield return new WaitForSeconds(blinkTime / blinkCount / 2);

                time -= blinkTime / blinkCount / 2;
            }

            //사망시
            if (monState == MonsterState.Die)
            {
                //사망 이펙트 추가 //터짐
                BombEffect();
                //3. 효과 이후 몬스터 삭제
                Destroy(this.gameObject);
            }
        }
        //넉백 효과
        public void KnockBack(float xPower, float yPower)
        {
            if (monInfo.monKind != MonsterKind.Dig)
            {
                rigid.velocity = new Vector2(-transform.forward.x * xPower, rigid.velocity.y + yPower);
            }
        }

        private void Die()
        {
            //사망 상태로 변경
            monState = MonsterState.Die;

            //몬스터 사망시 효과
            StartCoroutine(BlinkMonster(0.5f, 2));
        }

        private void BombEffect()
        {
            SpriteRenderer effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
            effect.transform.parent = transform.parent;
        }
    }
}