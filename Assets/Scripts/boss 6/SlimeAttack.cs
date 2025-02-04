using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    public GameObject slimeProjectilePrefab;
    public float attackCooldown = 5f;
    public float slimeSpeed = 10f;
    public int slimeCount = 8;
    public float moveSpeed = 3f;
    public Vector2 centerPosition = new Vector2(0, 0);

    private float nextAttackTime = 0f;
    private bool isAttacking = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAttacking)
        {
            AttackWithSlime();
        }
        else
        {
            MoveToCenter();
        }
    }

    void MoveToCenter()
    {
        if ((Vector2)transform.position != centerPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, centerPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            isAttacking = true;
        }
    }

    void AttackWithSlime()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCooldown;
            animator.SetTrigger("Attack");

            for (int i = 0; i < slimeCount; i++)
            {
                float angle = i * (360f / slimeCount);
                Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle)).normalized;
                GameObject slimeProjectile = Instantiate(slimeProjectilePrefab, transform.position, Quaternion.identity);
                Rigidbody2D rb = slimeProjectile.GetComponent<Rigidbody2D>();
                rb.linearVelocity = direction * slimeSpeed;
            }

            isAttacking = false;
        }
    }
}