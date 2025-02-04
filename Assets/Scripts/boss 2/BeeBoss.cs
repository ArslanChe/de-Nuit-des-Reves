using UnityEngine;

public class BeeBoss : MonoBehaviour
{
    public float speed = 3f;
    public int maxHealth = 200;
    public int currentHealth;
    public Transform[] patrolPoints;
    public float waitTime = 2f;
    
    private int currentPointIndex = 0;
    private bool isWaiting = false;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (!isWaiting)
        {
            Move();
        }
    }

    void Move()
    {
        Transform targetPoint = patrolPoints[currentPointIndex];
        Vector2 direction = (targetPoint.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            rb.linearVelocity = Vector2.zero;
            isWaiting = true;
            Invoke("NextPoint", waitTime);
        }
    }

    void NextPoint()
    {
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        isWaiting = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 1f);
    }
}