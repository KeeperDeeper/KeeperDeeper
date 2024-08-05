using System;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : IManagers
{
    public Action<KeyCode, Defines.KeyInputType> keyAction;
    public Action<MouseButton, Defines.MouseInputType> mouseInputAction;

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
            if (Input.GetKeyDown(KeyCode.Tab))
                keyAction.Invoke(KeyCode.Tab, Defines.KeyInputType.Down);
            if (Input.GetKeyDown(KeyCode.Escape))
                keyAction.Invoke(KeyCode.Escape, Defines.KeyInputType.Down);
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

        if (mouseInputAction != null)
        {
            #region MouseDown
            if (Input.GetMouseButtonDown((int)MouseButton.Left))
                mouseInputAction.Invoke(MouseButton.Left, Defines.MouseInputType.Down);
            if (Input.GetMouseButtonDown((int)MouseButton.Right))
                mouseInputAction.Invoke(MouseButton.Right, Defines.MouseInputType.Down);
            #endregion
        }
    }
}
