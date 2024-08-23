using OxygenSystem;
using System;

public class GameManager : IManagers
{
    private Oxygen oxygen;

    public bool endStage;

    public Action interactAction;
    public bool isBlockingUserInput;
    public bool blockInput;

    public void Init()
    {
        blockInput = false;
        isBlockingUserInput = false;
        oxygen = UnityEngine.Object.FindObjectOfType<Oxygen>();
        endStage = false;
        oxygen.InitOxygenTank(); //산소 초기화
    }

    public void TryInteract()
    {
        if (interactAction != null)
        {
            interactAction.Invoke();
        }
    }

    public void EndStage()
    {
        endStage = true; //스테이지 종료
        oxygen.endGame = endStage; //게임종료 정보 넘기기
        oxygen.RecoveryOxygen();  //산소통 초기화
        //스테이지 종료 UI표시 추가해주기
    }
}