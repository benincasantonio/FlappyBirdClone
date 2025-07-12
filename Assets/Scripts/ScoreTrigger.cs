using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.IncreaseScore();
        // play a sound effect or visual feedback here if desired
        // For example, you could use AudioManager to play a sound effect
        
        Debug.Log("Score increased! Current score: " + GameManager.Instance.Score);  
    }
}