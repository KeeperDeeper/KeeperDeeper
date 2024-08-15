using Monster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTakeDamage : MonoBehaviour
{
    HashSet<MonsterBehavior> monster = new HashSet<MonsterBehavior>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            MonsterBehavior curMonster = collision.gameObject.GetComponent<MonsterBehavior>();
            if (!monster.Contains(curMonster))
            {
                //monster.Add(curMonster);
                curMonster.TakeDamage(10);
            }
        }
    }
}
