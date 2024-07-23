using System;
using UnityEngine;

public class InputManager : IManagers
{
    public Action<KeyCode, Defines.KeyInputType> keyAction;

    public void Init()
    {
        keyAction = null;
    }

    // 유니티 자체 Update가 아님. Managers.cs에서 사용하는 용도
    public void Update()
    {
        // keyAction에 등록된 메소드가 없는 경우 키 입력 이벤트 발생
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
