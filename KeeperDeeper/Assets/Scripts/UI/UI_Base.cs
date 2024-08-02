using UnityEngine;

public class UI_Base : MonoBehaviour
{
    public Defines.UIType uiType;

    public Defines.UIType GetUIType()
    {
        return uiType;
    }

    public void SetUIType(Defines.UIType uiType)
    {
        this.uiType = uiType;
    }

    public void CloseUI()
    {
        Destroy(gameObject);
    }
}
