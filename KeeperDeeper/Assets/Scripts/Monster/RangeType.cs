using Monster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeType : MonsterBehavior
{
    public GameObject atkObject;
    public float atkTime;

    protected override void Start()
    {
        base.Start();
        atkTime = monInfo.monsterInfo.attackTime;
    }
    protected override void Update()
    {
        base.Update();
        StateController();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    //플레이어 추격
    protected override void ChasePlayer()
    {
        base.ChasePlayer();
        if (playerRange <= monInfo.monsterInfo.attackRange)
        {
            atkTime -= Time.deltaTime;
            if (atkTime <= 0 && monCombat == MonsterCombat.None)
            {
                move = false;
                monCombat = MonsterCombat.AttackReady;
                animator.SetTrigger("Attack");                
            }
        }
    }
    private void Attack()
    {
        GameObject attack = Instantiate(atkObject, transform.position, Quaternion.identity); //공격오브젝트 생성
        if (direction == -1)
        {
            attack.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            attack.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        attack.transform.parent = FindObjectOfType<Canvas>().transform; //위치 생성
        MonsterAttack atk = attack.GetComponent<MonsterAttack>();
        atk.power = monInfo.monsterInfo.attack; //공격력 전달
        atk.Power(direction, monInfo.monsterInfo.attackSpeed); //투사체 방향 및 속도 전달
    }

    private void StateController()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.65f && monCombat == MonsterCombat.AttackReady)
            {
                monCombat = MonsterCombat.Attack;
                Attack();
            }
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                atkTime = monInfo.monsterInfo.attackTime;//공격 타임초기화
                animator.SetTrigger("Idle");
                monCombat = MonsterCombat.None;
            }
        }
    }
}
