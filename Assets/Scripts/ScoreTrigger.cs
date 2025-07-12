using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.IncreaseScore();
        Debug.Log("Score increased! Current score: " + GameManager.Instance.Score);  
    }
}