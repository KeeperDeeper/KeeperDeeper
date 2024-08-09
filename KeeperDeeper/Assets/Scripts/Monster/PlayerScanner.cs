using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class PlayerScanner : MonoBehaviour
    {
        [SerializeField]
        private MonsterBehavior monster;
        [SerializeField]
        private BoxCollider2D scanCollider;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerScan();
            }
        }
        private void PlayerScan()
        {
            this.monster.monState = MonsterState.Chase;
        }
    }
}