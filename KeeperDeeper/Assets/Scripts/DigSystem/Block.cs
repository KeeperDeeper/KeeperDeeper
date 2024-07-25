using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DrillObject;

public class Block : MonoBehaviour
{
    public BlockInformation blockInformation;
    public float lifeTime;
    void Start()
    {
        blockInformation.Init();
        lifeTime = blockInformation.diggingTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //���� �Ĵ� ���� ��
        if (collision.gameObject.CompareTag("Drill"))
        {
            lifeTime -= Time.deltaTime * collision.GetComponent<Drill>().drillPo; //�帱power�� ���� �����ð�
            if (lifeTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //���Ĵ� ���� ������ ��
        if (collision.gameObject.CompareTag("Drill"))
        {
            if (lifeTime > 0)
            {
                lifeTime = blockInformation.diggingTime; //�ð� ����
            }
        }
    }
}
