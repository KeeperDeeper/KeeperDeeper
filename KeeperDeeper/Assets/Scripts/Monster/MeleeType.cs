using Monster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MeleeType : MonsterBehavior
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    //플레이어 추격
    protected override void ChasePlayer()
    {
        base.ChasePlayer();
        if (playerRange >= monInfo.monsterInfo.attackRange)
        {
            move = false;
            monInfo.monsterInfo.speed = monInfo.monsterInfo.attackSpeed;
            Attack();
        }
    }
    private void Attack()
    {
        monCombat = MonsterCombat.Attack;
        animator.SetBool("Move", move);
        animator.SetBool("Attack", !move);
    }
    private void StateController()
    {

    }
}