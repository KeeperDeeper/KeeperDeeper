using OxygenSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    HashSet<PlayerController> playerCon = new HashSet<PlayerController>();
    private Rigidbody2D rigid;
    private BoxCollider2D atkCol;
    private RectTransform rect;
    public int power;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        atkCol = GetComponent<BoxCollider2D>();
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        atkCol.size = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (!playerCon.Contains(player))
            {
                playerCon.Add(player);
                Oxygen oxygen = FindObjectOfType<Oxygen>();
                oxygen.DecreaseOxygen(power);
                DestroyObject();
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            DestroyObject();
        }
    }

    public void Power(float direction, float atkSpeed)
    {
        rigid.velocity = new Vector2(direction * atkSpeed, rigid.velocity.y);
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
