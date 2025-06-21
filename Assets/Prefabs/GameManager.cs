using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private bool isGamneStarted = false;

    public bool IsGameStarted
    {
        get { return isGamneStarted; }
        set { isGamneStarted = value; }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    

    public void StartGame()
    {
        if(isGamneStarted)
        {
            Debug.LogWarning("Game is already started.");
            return;
        }
        
        isGamneStarted = true;
        Debug.Log("Game started");
    }
}
