using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : IManagers
{
    /* 사용자의 입력에 의해 잦은 빈도로 활성화 여부가 바뀌는 경우
     * 동적UI로 정의하고, 그렇지 않은 경우 정적UI로 정의함.
     * 사용자의 입력에 영향을 받아서는 절대 안되기 때문에 정적 UI를 먼저 리스트에 넣어주고
     * 동적UI를 비활성화하는 경우 동적UI를 모두 비활성화했다면 정적UI에 접근하지 못하도록 제한해주는 인덱스 역할이 바로 다음에 있는 두 개의 정수형 변수
     */
    private int dynamicUICount;
    private int staticUICount;

    private Dictionary<Defines.UIType, int> uiCountsByType;
    private Transform mainCanvasTransform;
    private List<UI_Base> uiList;

    public void Init()
    {
        dynamicUICount = 0;
        staticUICount = 0;

        uiCountsByType = new Dictionary<Defines.UIType, int>();
        foreach (Defines.UIType uiType in Enum.GetValues(typeof(Defines.UIType)))
        {
            uiCountsByType.Add(uiType, 0);
        }
        mainCanvasTransform = GameObject.Find("MainCanvas").transform;
        uiList = new List<UI_Base>();
    }

    public bool CheckUIMountMargin(Defines.UIType uiType, int mount)
    {
        return uiCountsByType[uiType] < mount;
    }

    public void CreateUI(Defines.UIType uiType)
    {
        dynamicUICount++;
        uiCountsByType[uiType]++;
        GameObject uiObj = GameObject.Instantiate(Resources.Load<GameObject>($"Prefabs/{uiType}"), mainCanvasTransform);
        uiList.Add(uiObj.GetComponent<UI_Base>());
        uiList[dynamicUICount - 1].SetUIType(uiType);
    }

    public void CloseUI()
    {
        if (staticUICount >= dynamicUICount)
            return;

        dynamicUICount--;
        uiCountsByType[uiList[dynamicUICount].GetUIType()]--;

        uiList[dynamicUICount].CloseUI();
        uiList.RemoveAt(dynamicUICount);
    }
}
