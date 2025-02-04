using UnityEngine;

public class DuckBabyDuckAttack : MonoBehaviour
{
    public GameObject babyDuckPrefab;
    public float attackCooldown = 4f;
    public float spawnRate = 1f;
    public float explosionRadius = 2f;
    public int explosionDamage = 30;
    public float babyDuckSpeed = 3f;
    public Transform[] spawnPoints;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            SummonBabyDuck();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void SummonBabyDuck()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject babyDuck = Instantiate(babyDuckPrefab, spawnPoint.position, Quaternion.identity);
            BabyDuckController babyDuckController = babyDuck.GetComponent<BabyDuckController>();
            babyDuckController.Initialize(gameObject.transform, babyDuckSpeed, explosionRadius, explosionDamage);
        }
    }
}