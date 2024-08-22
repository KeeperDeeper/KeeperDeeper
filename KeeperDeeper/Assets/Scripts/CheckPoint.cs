using UnityEngine;
using OxygenSystem;

public class CheckPoint : MonoBehaviour
{
    public enum PointKind { Check, Finish}
    public PointKind pointKind;

    private Oxygen oxygen;

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
                Managers.StageManager.SaveStageData(curFloor);

                //비활성화
                gameObject.SetActive(false);
            }
            else if (pointKind == PointKind.Finish)
            {
                Managers.GameManager.EndStage();
            }
        }
    }
}
