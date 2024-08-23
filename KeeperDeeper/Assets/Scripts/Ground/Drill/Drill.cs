using System.Collections.Generic;
using UnityEngine;

//플레이어가 굴착시 상용할 Script
//드릴오브젝트에 넣을 Script
namespace DrillObject
{
    public class Drill : MonoBehaviour
    {
        public List<Block> blocks = new List<Block>();

        public DrillInformation drillInformation;
        [SerializeField]
        private BoxCollider2D boxCollider2D;

        public string drillName; //드릴 이름
        public int drillLv;//드릴 레벨
        public int drillPo;//드릴 힘
        public bool active;

        private void Awake()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }
        void Start()
        {
            ChangeDrillInformation();
            ActiveDrill();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("GroundBlock"))
            {
                if (collision.GetComponent<Block>() != null)
                {
                    Block block = collision.GetComponent<Block>();
                    if (!blocks.Contains(block))
                    {
                        blocks.Add(block);
                        if (blocks.Count > 1)
                        {
                            CaculateDistance();
                        }
                    }
                }
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.GetComponent<Block>() != null)
            {
                if (collision.CompareTag("GroundBlock"))
                {
                    if (blocks.Count > 0 && blocks[0].lifeTime > 0)
                    {
                        blocks[0].lifeTime -= Time.deltaTime * drillPo;
                    }
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("GroundBlock"))
            {
                blocks.Clear();
            }
        }
        //드릴 정보 변경
        public void ChangeDrillInformation()
        {
            drillName = drillInformation.drillName;
            drillLv = drillInformation.drillLevel;
            drillPo = drillInformation.drillPower;
        }
        public void ActiveDrill()
        {
            boxCollider2D.enabled = active;
        }
        private void CaculateDistance()
        {
            float[] distances = new float[2];
            for (int i = 0; i < blocks.Count; i++)
            {
                float x = this.transform.position.x - blocks[i].transform.position.x;
                float y = this.transform.position.y - blocks[i].transform.position.y;
                float distance = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
                distances[i] = distance;
                for (int j = 0; j < i; j++)
                {
                    if (j + 1 < i)
                    {
                        if (distances[j] <= distances[j + 1])
                        {
                            distances[j] = distances[j];
                        }
                        else if (distances[j] > distances[j + 1])
                        {
                            float temp = distances[j];
                            distances[j] = distances[j + 1];
                            distances[j] = temp;

                            Block tempblock = blocks[j];
                            blocks[j] = blocks[j + 1];
                            blocks[j + 1] = tempblock;
                        }
                    }
                }
            }
        }
    }
}