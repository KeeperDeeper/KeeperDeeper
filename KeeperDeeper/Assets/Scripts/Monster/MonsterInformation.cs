using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MonsterInfo
{
    public string monsterName; //���� �̸�
    public float speed; //���� �̵��ӵ�
    public int scanRange; //�÷��̾� ���� ����
    public int moveRange; //�̰��� �̵�����
    public int attack;
}
[CreateAssetMenu(fileName = "", menuName = "Monster", order = 2)]
public class MonsterInformation : ScriptableObject
{
    public MonsterInfo monsterInfo;
    public string monName; //���� �̸�
    public float speed; //�̵� �ӵ�
    public int range; //�ν� �� ĭ ��
    public int moveRange; //�̰��� �̵� ����
    public int attack; //����� �����

    public void InitMonster()
    {
        monsterInfo.monsterName = monName;
        monsterInfo.speed = speed;
        monsterInfo.scanRange = range * 100;
        monsterInfo.moveRange = moveRange * 100;
        monsterInfo.attack = attack;
    }
}
