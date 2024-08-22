using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OxygenSystem;
using StageManagement;

public class CheckPoint : MonoBehaviour
{
    public enum PointKind { Check, Finish}
    public PointKind pointKind;

    private Oxygen oxygen;
    private GameManager gameManager;
    private StageManager stageManager;

    [SerializeField]
    private int curFloor;
    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pointKind == PointKind.Check)
            {
                //산소회복
                oxygen = FindObjectOfType<Oxygen>();
                oxygen.check = true;
                oxygen.RecoveryOxygen();

                //데이터 저장
                stageManager = FindObjectOfType<StageManager>();
                stageManager.SaveStageData(curFloor);

                //비활성화
                gameObject.SetActive(false);
            }
            else if (pointKind == PointKind.Finish)
            {
                gameManager = FindObjectOfType<GameManager>();
                gameManager.EndStage();
            }
        }
    }
}
