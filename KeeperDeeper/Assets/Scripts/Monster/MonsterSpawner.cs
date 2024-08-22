using Monster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterObj;
    [SerializeField]
    private int monsterNum;

    void Start()
    {
        InstantiateMonster();
    }
    private void InstantiateMonster()
    {
        GameObject monster = Instantiate(monsterObj[monsterNum], transform.position, Quaternion.identity);
    }
}