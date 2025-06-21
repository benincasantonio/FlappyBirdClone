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
    private float spawnInterval = 2f;

    private float nextSpawnTime = 0f;


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
        Vector3 topPipePosition = new Vector3(6.8f, 6.7f, 0);
        Vector3 bottomPipePosition = new Vector3(6.8f, -6.7f, 0);

        GameObject topPipe = Instantiate(topPipePrefab, topPipePosition, Quaternion.identity);
        GameObject bottomPipe = Instantiate(bottomPipePrefab, bottomPipePosition, Quaternion.identity);

        if (topPipe == null || bottomPipe == null)
        {
            Debug.LogError("Failed to instantiate pipes. Check if prefabs are assigned.");
            return;
        }
    }
    
    public void StartSpawningPipes()
    {
        print("Starting pipe spawning.");
        nextSpawnTime = Time.time + spawnInterval;
    }
}
