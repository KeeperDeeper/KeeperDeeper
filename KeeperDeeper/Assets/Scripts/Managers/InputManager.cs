using System;
using UnityEngine;

public class InputManager : IManagers
{
    public Action<KeyCode, Defines.KeyInputType> keyAction;

    public void Init()
    {
        keyAction = null;
    }

    // ����Ƽ ��ü Update�� �ƴ�. Managers.cs���� ����ϴ� �뵵
    public void Update()
    {
        // keyAction�� ��ϵ� �޼ҵ尡 ���� ��� Ű �Է� �̺�Ʈ �߻�
        if (keyAction != null)
        {

        }
    }
}
