using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemId;
    public string itemName;
    public Sprite itemImg;

    public Item(int itemId, string itemName, Sprite itemImg)
    {
        this.itemId = itemId;
        this.itemName = itemName;
        this.itemImg = itemImg;
    }

    private void Awake()
    {
        if (gameObject != null)
        {
            name = itemName;
            GetComponent<SpriteRenderer>().sprite = itemImg;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.transform.tag == "Player")
            {
                Managers.DataManager.playerInventory.AddItem(this);
                Destroy(gameObject);
            }
        }
    }
}
