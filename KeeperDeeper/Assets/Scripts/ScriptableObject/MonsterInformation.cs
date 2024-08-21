using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterKind { Melee, Range, Dig}
public enum MonsterState { Wait, Move, Chase, Die }
public enum MonsterCombat { None, AttackReady, Attack }
public enum MonsterMove { Left, Right, Stop };

public struct MonsterInfo
{
    public string monsterName; //몬스터 이름
    public int hp; //몬스터 체력
    public float speed; //몬스터 이동속도
    public float scanRange; //플레이어 감지 범위
    public float attackRange; //공격 범위
    public float attackTime; //공격 쿨타임
    public float attackSpeed; //공격 속도
    public int attack;
}
[CreateAssetMenu(fileName = "", menuName = "Monster", order = 2)]
public class MonsterInformation : ScriptableObject
{
    public MonsterKind monKind;
    public MonsterInfo monsterInfo;
    public string monName; //몬스터 이름
    public int hp;
    public float speed; //이동 속도
    public float range; //인식 블럭 칸 수
    public float atkRange; //공격거리
    public float atkTime;
    public float atkSpeed;
    public int attack; //산소통 대미지

    public void InitMonster()
    {
        monsterInfo.monsterName = monName;
        monsterInfo.hp = hp;
        monsterInfo.speed = speed;
        monsterInfo.scanRange = range * 1.5f;
        monsterInfo.attackRange = atkRange * 1.5f;
        monsterInfo.attackTime = atkTime;
        monsterInfo.attackSpeed = atkSpeed;
        monsterInfo.attack = attack;
    }
}
