using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : IManagers
{
    /* ������� �Է¿� ���� ���� �󵵷� Ȱ��ȭ ���ΰ� �ٲ�� ���
     * ����UI�� �����ϰ�, �׷��� ���� ��� ����UI�� ������.
     * ������� �Է¿� ������ �޾Ƽ��� ���� �ȵǱ� ������ ���� UI�� ���� ����Ʈ�� �־��ְ�
     * ����UI�� ��Ȱ��ȭ�ϴ� ��� ����UI�� ��� ��Ȱ��ȭ�ߴٸ� ����UI�� �������� ���ϵ��� �������ִ� �ε��� ������ �ٷ� ������ �ִ� �� ���� ������ ����
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
