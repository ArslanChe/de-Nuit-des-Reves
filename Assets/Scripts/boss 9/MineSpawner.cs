using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public GameObject minePrefab;
    public float spawnCooldown = 3f;
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnMine();
        }
    }

    void SpawnMine()
    {
        nextSpawnTime = Time.time + spawnCooldown;
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        GameObject mine = Instantiate(minePrefab, spawnPosition, Quaternion.identity);
    }
}