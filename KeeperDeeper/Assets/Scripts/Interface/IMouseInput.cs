/* ���콺 �Է��� �޴� ��Ʈ�ѷ��� ���� �������̽�
 * �޼ҵ� ���� �� �̺�Ʈ�� �޾ƾ� �ϴ� ��� �̺�Ʈ ����ؼ� ����� ��
 */

using Unity.VisualScripting;
using UnityEngine;

interface IMouseInput
{
    void MouseInput(MouseButton button, Defines.MouseInputType inputType);
}
