using OxygenSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Oxygen oxygen;

    public bool endStage;

    private void Awake()
    {
        oxygen = FindObjectOfType<Oxygen>();
    }

    private void Start()
    {
        endStage = false;
        oxygen.InitOxygenTank(); //산소 초기화
    }

    public void EndStage()
    {
        endStage = true; //스테이지 종료
        oxygen.endGame = endStage; //게임종료 정보 넘기기
        oxygen.RecoveryOxygen();  //산소통 초기화
    }
}