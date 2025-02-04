using UnityEngine;

public class SnailBossController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float moveSpeed = 2f;
    public float sprintSpeed = 6f;  
    public float attackRange = 1.5f;
    public float attackCooldown = 3f;  
    private float nextAttackTime = 0f;
    
    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                PerformMeleeAttack();
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    void PerformMeleeAttack()
    {
        nextAttackTime = Time.time + attackCooldown; 
        rb.linearVelocity = Vector2.zero;  
        StartCoroutine(SprintTowardsPlayer());
    }

    System.Collections.IEnumerator SprintTowardsPlayer()
    {
        float elapsedTime = 0f;
        Vector2 originalPosition = transform.position;
        while (elapsedTime < 0.5f) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, sprintSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        CheckPlayerHit();  
    }

    void CheckPlayerHit()
    {
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(30); 
            }
        }
    }

    public void TakeDamage(int damage)
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
        Debug.Log("Улитка уничтожена!");
    }
}
