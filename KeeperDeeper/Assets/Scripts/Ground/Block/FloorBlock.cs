using UnityEngine;

public class FloorBlock : MonoBehaviour
{
    public int floorNum;
    private void Awake()
    {
        
    }
    private void Start()
    {
        this.gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Managers.StageManager.ChangeFloorNumber(floorNum); //類熱 滲唳
            Managers.StageManager.CountUnderGroundFloor(); //雖ж 類熱 蘋遴た
            this.gameObject.SetActive(false);
        }
    }
}
