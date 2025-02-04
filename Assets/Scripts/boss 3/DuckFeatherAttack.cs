using UnityEngine;

public class DuckFeatherAttack : MonoBehaviour
{
    public GameObject featherPrefab;
    public float attackCooldown = 3f;
    public float featherSpeed = 5f;
    public float featherLifetime = 5f;
    public int featherDamage = 10;
    public float spreadAngle = 45f;  
    public Transform[] spawnPoints;  

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            LaunchFeathers();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void LaunchFeathers()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            float angle = Random.Range(-spreadAngle, spreadAngle);  
            Vector3 direction = Quaternion.Euler(0f, 0f, angle) * spawnPoint.right;

            GameObject feather = Instantiate(featherPrefab, spawnPoint.position, Quaternion.identity);
            FeatherController featherController = feather.GetComponent<FeatherController>();
            featherController.Initialize(direction, featherSpeed, featherLifetime, featherDamage);
        }
    }
}