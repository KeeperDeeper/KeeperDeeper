using UnityEngine;

public class Managers : MonoBehaviour
{
    #region Managers �ν��Ͻ�
    private static GameObject _managerObj = null;
    public static GameObject ManagerObj { get { return _managerObj; } }

    private static Managers _managerInstance = null;
    public static Managers ManagerInstance { get { return _managerInstance; } }
    #endregion

    #region ��Ÿ �Ŵ��� �ν��Ͻ�
    private static InputManager _inputManager = new InputManager();
    private static UIManager _uiManager = new UIManager();

    public static InputManager InputManager { get { return _inputManager; } }
    public static UIManager UIManager { get { return _uiManager; } }
    #endregion


    void Awake()
    {
        // �̱���. �ν��Ͻ��� �̹� ����� �ı�
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
        // ��ũ��Ʈ�� �۵��ߴµ� �ν��Ͻ� �Ҵ��� �ȵưų� �Ŵ��� ���ӿ�����Ʈ�� ���� ��� ���
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
