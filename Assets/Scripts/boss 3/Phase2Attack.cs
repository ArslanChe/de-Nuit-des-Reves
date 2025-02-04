using UnityEngine;

public class Phase2Attack : MonoBehaviour
{
    public GameObject bombPrefab; 
    public float spawnCooldown = 2f;
    public float bombSpeed = 4f;
    public int bombDamage = 50;

    private float nextSpawnTime = 0f;
    private Transform boss;

    public void Initialize(Transform bossTransform)
    {
        boss = bossTransform;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            LaunchBomb();
            nextSpawnTime = Time.time + spawnCooldown;
        }
    }

    void LaunchBomb()
    {
        if (boss != null)
        {
            Vector3 spawnPosition = boss.position + new Vector3(0f, 2f, 0f); 
            GameObject bomb = Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
            BombController bombController = bomb.GetComponent<BombController>();
            bombController.Initialize(boss.position, bombSpeed, bombDamage);
        }
    }
}