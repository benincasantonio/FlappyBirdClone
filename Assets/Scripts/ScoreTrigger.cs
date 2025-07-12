using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    private AudioClip scoreSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component not found on ScoreTrigger. Please add one for sound effects.");
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.IncreaseScore();
        }

        Debug.Log("Score increased! Current score: " + GameManager.Instance.Score);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        PlayScoreSound();
    }

    private void PlayScoreSound()
    {
        if (audioSource != null && scoreSound != null)
        {
            audioSource.PlayOneShot(scoreSound);
        }
        else
        {
            Debug.LogWarning("AudioSource or score sound not set on ScoreTrigger.");
        }
    }
}