/* 키 입력을 받는 컨트롤러를 위한 인터페이스
 * 메소드 구현 후 이벤트를 받아야 하는 경우 이벤트 등록해서 사용할 것
 */

using UnityEngine;

interface IKeyInput
{
    void KeyInput(KeyCode keyCode, Defines.KeyInputType inputType);
}
