using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : IManagers
{
    public int dynamicUICount;
    public int staticUICount;
    private Transform mainCanvasTransform;
    List<UI_Base> uiList;

    public void Init()
    {
        dynamicUICount = 0;
        staticUICount = 0;
        mainCanvasTransform = GameObject.Find("MainCanvas").transform;
        uiList = new List<UI_Base>();
    }

    public void CreateUI()
    {
        dynamicUICount++;
        uiList.Add(GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/TestUI"), mainCanvasTransform).GetComponent<UI_Base>());
    }

    public void CloseUI()
    {
        if (staticUICount >= dynamicUICount)
            return;
        dynamicUICount--;
        uiList[dynamicUICount].CloseUI();
        uiList.RemoveAt(dynamicUICount);
    }
}
