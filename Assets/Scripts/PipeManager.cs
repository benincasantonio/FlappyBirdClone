using UnityEngine;

public class PipeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject topPipePrefab;
    [SerializeField]
    private GameObject bottomPipePrefab;

    [SerializeField]
    /// <summary>
    /// Interval in seconds between pipe spawns.
    /// </summary>
    private float spawnInterval = 3f;

    [SerializeField]
    [Range(2f, 5f)]
    /// <summary>
    /// The size of the gap between the top and bottom pipes.
    /// </summary>
    private float gapSize = 3f;

    /// <summary>
    /// The X position where pipes will spawn.
    /// </summary>
    private const float SPAWN_POSITION_X = 6.8f;

    /// <summary>
    /// The time when the next pipes will spawn.
    /// </summary>
    private float nextSpawnTime = 0f;

    private float minGapCenterY;
    private float maxGapCenterY;

    /// <summary>
    /// The size of the pipe, used to calculate the position of the top pipe.
    /// </summary>
    private float pipeSize;



    private static PipeManager instance;

    public static PipeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<PipeManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("PipeManager");
                    instance = go.AddComponent<PipeManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (topPipePrefab == null || bottomPipePrefab == null)
        {
            Debug.LogError("Pipe prefabs are not assigned in the PipeManager.");
            return;
        }

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        pipeSize = topPipePrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        CalculateGapCenters();
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameStarted && Time.time >= nextSpawnTime)
        {
            SpawnPipes();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnPipes()
    {
        float gapCenterY = Random.Range(minGapCenterY, maxGapCenterY);

        float gapTopY = gapCenterY + gapSize / 2f;
        float gapBottomY = gapCenterY - gapSize / 2f;

        float topPipeY = gapTopY + (pipeSize / 2f);
        float bottomPipeY = gapBottomY - (pipeSize / 2f);

        Vector3 topPipePosition = new Vector2(SPAWN_POSITION_X, topPipeY);
        Vector3 bottomPipePosition = new Vector2(SPAWN_POSITION_X, bottomPipeY);

        GameObject topPipe = Instantiate(topPipePrefab, topPipePosition, Quaternion.identity);
        GameObject bottomPipe = Instantiate(bottomPipePrefab, bottomPipePosition, Quaternion.identity);

        if (topPipe == null || bottomPipe == null)
        {
            Debug.LogError("Failed to instantiate pipes. Check if prefabs are assigned.");
            return;
        }
    }

    void CalculateGapCenters()
    {
        float cameraHeight = Camera.main.orthographicSize * 2f;

        minGapCenterY = -cameraHeight / 2f + gapSize / 2f;
        maxGapCenterY = cameraHeight / 2f - gapSize / 2f;
    }
    
    public void StartSpawningPipes()
    {
        print("Starting pipe spawning.");
        nextSpawnTime = Time.time + spawnInterval;
    }
}
