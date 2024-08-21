using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;
    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0)
        {
            DestroyEffect();
        }
    }
    private void DestroyEffect()
    {
        Destroy(this.gameObject);
    }
}
