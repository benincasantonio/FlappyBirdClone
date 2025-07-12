using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    [SerializeField]
    private TMPro.TMP_Text scoreText;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<UIManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("UIManager");
                    instance = go.AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }
    
    public void UpdateTextScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
