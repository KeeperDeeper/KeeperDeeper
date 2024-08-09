using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DrillObject;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public BlockInformation blockInformation;
    public Floor floor;
    public float lifeTime;

    void Start()
    {
        blockInformation.Init();
        blockInformation.blockInfo.active = true;
        lifeTime = blockInformation.diggingTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //���� �Ĵ� ���� ��
        if (collision.gameObject.CompareTag("Drill") && blockInformation.blockStr != BlockInfo.BlockStrength.Lv0)
        {
            lifeTime -= Time.deltaTime * collision.GetComponent<Drill>().drillPo; //�帱power�� ���� �����ð�
            if (lifeTime <= 0)
            {
                blockInformation.blockInfo.active = false;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //���Ĵ� ���� ������ ��
        if (collision.gameObject.CompareTag("Drill") && blockInformation.blockStr != BlockInfo.BlockStrength.Lv0)
        {
            if (lifeTime > 0)
            {
                lifeTime = blockInformation.diggingTime; //�ð� ����
            }
        }
    }
}