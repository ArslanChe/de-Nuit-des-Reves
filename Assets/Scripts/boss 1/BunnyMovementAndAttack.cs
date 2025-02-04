using UnityEngine;

public class BunnyMovementAndAttack : MonoBehaviour
{
    public float speed = 3f;
    public float attackRange = 1.5f;
    public int damage = 10;
    public float attackCooldown = 2f;
    
    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;
    private float nextAttackTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange)
        {
            MoveTowardsPlayer();
        }
        else if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);
        animator.SetBool("isMoving", true);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    void DealDamage()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRange, LayerMask.GetMask("Player"));
        if (hit != null)
        {
            hit.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }
    }
}