using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DrillObject;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public BlockInformation blockInformation;
    public Floor floor;
    private SpriteRenderer spriteRender;
    public float lifeTime;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        blockInformation.Init();
        blockInformation.blockInfo.active = true;
        lifeTime = blockInformation.diggingTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //¶¥À» ÆÄ´Â ÁßÀÏ ¶§
        if (collision.gameObject.CompareTag("Drill"))
        {
            if (blockInformation.blockStr != BlockStrength.Wall)
            {
                lifeTime -= Time.deltaTime * collision.GetComponent<Drill>().drillPo; //µå¸±power¿¡ µû¸¥ ±¼Âø½Ã°£
                if (0f < lifeTime && lifeTime <= blockInformation.diggingTime / 2)
                {
                    spriteRender.sprite = blockInformation.crackSprite;
                }
                else if (lifeTime < 0f)
                {
                    blockInformation.blockInfo.active = false;
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //¶¥ÆÄ´Â °ÍÀ» ¸ØÃèÀ» ¶§
        if (collision.gameObject.CompareTag("Drill"))
        {
            if (lifeTime > 0f)
            {
                lifeTime = blockInformation.diggingTime; //½Ã°£ ¸®¼Â
                spriteRender.sprite = blockInformation.originSprite;
            }
        }
    }
}