using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        Utils.GetMainCameraLeftRightEdge(out leftEdge, out rightEdge);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameStarted)
        {
            MovePipe();
        }

    }

    private void MovePipe()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
        if (leftEdge - transform.position.x > 3f)
        {
            Destroy(gameObject);
        }
    }
}
