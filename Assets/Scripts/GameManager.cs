using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private bool isGamneStarted = false;
    private TMP_Text scoreText;

    private int score = 0;

    public int Score
    {
        get { return score; }
    }

    public void IncreaseScore()
    {
        score++;
        UIManager.Instance.UpdateTextScore(score);
    }

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
        UIManager.Instance.UpdateTextScore(score);

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
        PipeManager.Instance.StartSpawningPipes();
        Debug.Log("Game started");
    }
}
