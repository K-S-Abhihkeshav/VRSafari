using UnityEngine;

public class wolfspawner : MonoBehaviour
{
    public GameObject wolfPrefab;
    public float spawnInterval = 3f;
    public Vector3 spawnAreaMin = new Vector3(-100, 0, -100);
    public Vector3 spawnAreaMax = new Vector3(100, 0, 100);

    void Start()
    {
        // Start spawning wolves repeatedly
        InvokeRepeating("SpawnWolf", 0f, spawnInterval);
    }

    void SpawnWolf()
    {
        // Generate random position within constraints
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        // Create wolf instance
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        GameObject wolf = Instantiate(wolfPrefab, spawnPosition, randomRotation);
        
        // Automatically destroy after 10 seconds
        Destroy(wolf, 180f);
    }

    // Visualize spawn area in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Vector3 center = (spawnAreaMax + spawnAreaMin) / 2;
        Vector3 size = spawnAreaMax - spawnAreaMin;
        Gizmos.DrawCube(center, size);
    }
}