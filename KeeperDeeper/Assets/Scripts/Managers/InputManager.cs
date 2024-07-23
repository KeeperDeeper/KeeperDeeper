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
            #region KeyDown
            if (Input.GetKeyDown(KeyCode.Space))
                keyAction.Invoke(KeyCode.Space, Defines.KeyInputType.Down);
            #endregion

            #region KeyPress
            if (Input.GetKey(KeyCode.A))
                keyAction.Invoke(KeyCode.A, Defines.KeyInputType.Press);
            if (Input.GetKey(KeyCode.D))
                keyAction.Invoke(KeyCode.D, Defines.KeyInputType.Press);
            #endregion

            #region KeyUp

            #endregion
        }
    }
}
