using System.Collections;
using UnityEngine;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    [SerializeField]
    private int itemId;
    [SerializeField]
    private float waitTime = 2.0f;
    private bool isCanGet;

    private void Start()
    {
        // 아이템 ID만으로 메니저의 Item DB에서 정보를 가져오는 방식.
        if (gameObject != null)
        {
            name = Managers.DataManager.itemDB[itemId].itemName;
            GetComponent<SpriteRenderer>().sprite = Managers.DataManager.itemDB[itemId].itemImg;
        }
        isCanGet = false;
        StartCoroutine(GetItemDelay(waitTime));
    }

    public void SetItemId(int itemId)
    {
        this.itemId = itemId;
    }

    IEnumerator GetItemDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isCanGet = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.transform.tag == "Player")
            {
                if (!isCanGet)
                    return;
                Managers.DataManager.playerInventory.AddItem(this.itemId);
                Destroy(gameObject);
            }
        }
    }
}
