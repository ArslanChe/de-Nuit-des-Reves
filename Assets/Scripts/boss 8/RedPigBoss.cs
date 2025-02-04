using UnityEngine;

public class RedPigBoss : MonoBehaviour
{
    public float maxHealth = 200f;
    private float currentHealth;
    public float moveSpeed = 5f;
    public int damage = 30;
    public float dirtThrowCooldown = 5f;
    private float nextDirtThrowTime = 0f;
    public GameObject dirtPrefab;
    public Transform dirtSpawnPoint;

    private Transform player;
    private bool isCharging;

    void Start()
    {
        currentHealth = maxHealth;
        player = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        MoveTowardsPlayer();

        if (Time.time >= nextDirtThrowTime)
        {
            ThrowDirt();
        }
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, player.position) < 1.5f)
            {
                PerformMeleeAttack();
            }
        }
    }

    void PerformMeleeAttack()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    void ThrowDirt()
    {
        nextDirtThrowTime = Time.time + dirtThrowCooldown;

        if (dirtPrefab != null && dirtSpawnPoint != null)
        {
            GameObject dirt = Instantiate(dirtPrefab, dirtSpawnPoint.position, Quaternion.identity);
            Vector3 direction = (player.position - dirtSpawnPoint.position).normalized;
            Rigidbody2D dirtRb = dirt.GetComponent<Rigidbody2D>();
            dirtRb.linearVelocity = direction * 10f; 
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
