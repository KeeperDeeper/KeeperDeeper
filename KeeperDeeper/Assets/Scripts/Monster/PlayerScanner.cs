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
                PlayerScan(collision);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GetOutOfScanner();
            }
        }
        private void PlayerScan(Collider2D player)
        {
            this.monster.monState = MonsterState.Chase;
            monster.target = player.transform;
        }
        private void GetOutOfScanner()
        {
            this.monster.monCombat = MonsterCombat.None;
            this.monster.MovePattern();
        }
        public void SetScannerSize()
        {
            scanCollider.size = new Vector2(monster.monInfo.monsterInfo.scanRange, 150);
        }
    }
}