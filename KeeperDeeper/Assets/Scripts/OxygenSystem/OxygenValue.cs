using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OxygenSystem;

public class OxygenValue : MonoBehaviour
{
    [SerializeField]
    private Slider oxygenGage;
    [SerializeField]
    private Oxygen oxygen;
    public void ChangeOxygenValue()
    {
        oxygenGage.value = oxygen.oxyCapacity / oxygen.maxOxyCapacity;
    }
}