using UnityEngine;

public class Managers : MonoBehaviour
{
    #region Managers 인스턴스
    private static GameObject _managerObj = null;
    public static GameObject ManagerObj { get { return _managerObj; } }

    private static Managers _managerInstance = null;
    public static Managers ManagerInstance { get { return _managerInstance; } }
    #endregion

    #region 기타 매니저 인스턴스
    private static InputManager _inputManager = new InputManager();
    private static UIManager _uiManager = new UIManager();

    public static InputManager InputManager { get { return _inputManager; } }
    public static UIManager UIManager { get { return _uiManager; } }
    #endregion


    void Awake()
    {
        // 싱글톤. 인스턴스가 이미 존재시 파괴
        if (_managerInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        Init();
    }

    private void Update()
    {
        InputManager.Update();
    }

    static private void Init()
    {
        // 스크립트는 작동했는데 인스턴스 할당이 안됐거나 매니저 게임오브젝트가 없는 경우 대비
        if (_managerInstance == null)
        {
            GameObject go = GameObject.Find("@Manager");
            if (go == null)
            {
                go = new GameObject { name = "@Manager" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            _managerInstance = go.GetComponent<Managers>();
        }

        if (_managerObj == null)
        {
            _managerObj = _managerInstance.gameObject;
        }

        InputManager.Init();
        UIManager.Init();
    }
}
