using UnityEngine;

public class WaterObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 3f;
    private float timer = 0f;
    public float heightOffset = 1.5f;
    private bool hardMode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hardMode = PlayerPrefs.GetInt("Difficulty", 0) == 1;

        spawnRate = hardMode ? 1.5f : 2f;

        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }
    void SpawnObstacle()
    {
        float randomHeight = Random.Range(-heightOffset, heightOffset);

        Vector3 spawnPosition = transform.position + Vector3.up * randomHeight;

        GameObject obstacle = Instantiate(
            obstaclePrefab,
            spawnPosition,
            Quaternion.identity
        );


        Transform top = obstacle.transform.Find("obstacle_top");
        Transform bottom = obstacle.transform.Find("obstacle_bottom");

        if (top != null && bottom != null)
        {
            float gapOffset = hardMode ? -0.5f : 0.5f;

            top.localPosition += Vector3.up * gapOffset;
            bottom.localPosition += Vector3.down * gapOffset;
        }

        WaterObstacleMovement movement =
            obstacle.GetComponent<WaterObstacleMovement>();

        if (movement != null)
        {
            movement.moveSpeed = hardMode ? 6f : 4f;
        }
    }

}

