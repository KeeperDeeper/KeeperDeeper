using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState { Wait, Move, Chase, Die }
public enum MonsterCombat { None, Damage }
public enum MonsterMove { Left, Right, Stop };
public struct MonsterInfo
{
    public string monsterName; //몬스터 이름
    public int hp; //몬스터 체력
    public float speed; //몬스터 이동속도
    public float scanRange; //플레이어 감지 범위
    public int attack;
}
[CreateAssetMenu(fileName = "", menuName = "Monster", order = 2)]
public class MonsterInformation : ScriptableObject
{
    public MonsterInfo monsterInfo;
    public string monName; //몬스터 이름
    public int hp;
    public float speed; //이동 속도
    public float range; //인식 블럭 칸 수
    public int attack; //산소통 대미지

    public void InitMonster()
    {
        monsterInfo.monsterName = monName;
        monsterInfo.hp = hp;
        monsterInfo.speed = speed;
        monsterInfo.scanRange = range * 100;
        monsterInfo.attack = attack;
    }
}
