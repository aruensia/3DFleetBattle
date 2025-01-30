using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    public static Manager Instance
    {
        get
        {
            return instance;
        }
    }

    public GameManager GameMgr { get; } = new();
    public UIScript UiMgr { get; }

    public Player PlayerMgr { get; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if ( instance != null )
        {
            Destroy(gameObject);
        }

    }
}
