using Monster;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DiggingType : MonsterBehavior
{
    public float atkTime;
    [SerializeField]
    private Floor floor;
    public Block curGround;
    public Block nextGround;
    private Vector2 nextPos;

    protected override void Start()
    {
        base.Start();
        atkTime = monInfo.monsterInfo.attackTime;
    }
    protected override void Update()
    {
        base.Update();
        if (monCombat == MonsterCombat.Attack && monState != MonsterState.Die)
        {
            Attack();
            ChangeBlock();
        }

        StateControl();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FloorBlock"))
        {
            Floor newFloor = collision.gameObject.GetComponent<Floor>();
            if (floor == null || floor != newFloor)
            {
                floor = collision.gameObject.GetComponentInParent<Floor>();
            }
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D (collision);
        
        //새로운 위치의 블럭으로 들어갔을 때
        if (collision.gameObject.CompareTag("GroundBlock"))
        {
            Block block = collision.gameObject.GetComponent<Block>();

            if (curGround == null) //처음 시작시 초기화
            {
                curGround = block;
            }

            if (block == nextGround && monCombat == MonsterCombat.Attack)
            {
                curGround = block; //다음블럭으로 이동했을 때, 현재 블럭으로 바꾸기
            }
        }
    }
    private void StateControl()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && monCombat == MonsterCombat.Attack)
            {
                animator.SetTrigger("Idle");
                monCombat = MonsterCombat.None;
                atkTime = monInfo.monsterInfo.attackTime;
            }
        }
    }
    //플레이어 추격
    protected override void ChasePlayer()
    {
        base.ChasePlayer();
        atkTime -= Time.deltaTime;
        if (atkTime <= 0 && curGround != null && monCombat == MonsterCombat.None)
        {
            FindNextBlock();
        }
    }
   
    private void FindNextBlock()
    {
        for (int i = 0; i < floor.blockObj.Length; i++)
        {
            if (floor.blockObj[i] == curGround)
            {
                if (direction == -1) //왼쪽
                {
                    if (i - 3 < 0) //범위내에 블록이 없다면
                    {
                        nextGround = floor.blockObj[0]; //왼쪽 끝 블럭 위치로
                    }
                    else if (i - 3 >= 0)
                    {
                        nextGround = floor.blockObj[i - 2]; //다음 왼쪽 세번째 블록
                    }
                }
                else if (direction == 1) //오른쪽
                {
                    if (floor.blockObj.Length - 1 < i + 3) //범위 내에 블록이 없다면
                    {
                        nextGround = floor.blockObj[^1]; //마지막 블록위치로
                    }
                    else if (floor.blockObj.Length >= i + 3)
                    {
                        nextGround = floor.blockObj[i + 3]; //다음 오른쪽 세번째 블록
                    }
                }
                nextPos = new Vector2(nextGround.transform.position.x, transform.position.y);
                break;
            }
        }
        animator.SetTrigger("Attack");
        monCombat = MonsterCombat.Attack;
    }
    private void ChangeBlock()
    {
        
    }

    private void Attack()
    {
        transform.position = Vector2.Lerp(transform.position, nextPos, 0.01f);
    }
}