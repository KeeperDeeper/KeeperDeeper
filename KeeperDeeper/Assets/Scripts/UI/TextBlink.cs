using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    [SerializeField]
    private float interval;
    private TextMeshProUGUI pressKey;

    private void Start()
    {
        pressKey = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Blink());
    }
    IEnumerator Blink()
    {
        while (true)
        {
            pressKey.text = "";
            yield return new WaitForSeconds(interval);
            pressKey.text = "Press Any Key To Start";
            yield return new WaitForSeconds(interval);
        }
    }
}
