using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OxygenSystem;
using StageManagement;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private Oxygen oxygen;
    [SerializeField]
    private StageManager stageManager;
    [SerializeField]
    private int curFloor;
    private void Start()
    {
        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //���ȸ��
            this.oxygen = FindObjectOfType<Oxygen>();
            oxygen.check = true;
            oxygen.RecoveryOxygen();

            //������ ����
            this.stageManager = FindObjectOfType<StageManager>();
            stageManager.SaveStageData(curFloor);

            //��Ȱ��ȭ
            this.gameObject.SetActive(false);
        }
    }
}
