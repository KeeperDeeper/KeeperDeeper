using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemId;

    private void Start()
    {

        if (gameObject != null)
        {
            name = Managers.DataManager.itemDB[itemId].itemName;
            GetComponent<SpriteRenderer>().sprite = Managers.DataManager.itemDB[itemId].itemImg;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.transform.tag == "Player")
            {
                Managers.DataManager.playerInventory.AddItem(this.itemId);
                Destroy(gameObject);
            }
        }
    }
}
