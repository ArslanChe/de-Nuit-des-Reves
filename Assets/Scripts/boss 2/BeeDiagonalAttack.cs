using UnityEngine;

public class BeeDiagonalAttack : MonoBehaviour
{
    public float attackSpeed = 10f;
    public float attackCooldown = 4f;
    public float attackDuration = 0.5f;

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 attackDirection;
    private bool isAttacking = false;
    private float nextAttackTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null || Time.time < nextAttackTime || isAttacking) return;

        StartDiagonalAttack();
        nextAttackTime = Time.time + attackCooldown;
    }

    void StartDiagonalAttack()
    {
        isAttacking = true;
        attackDirection = (player.position - transform.position).normalized + Vector3.up;
        attackDirection.Normalize();

        rb.linearVelocity = attackDirection * attackSpeed;
        Invoke("StopAttack", attackDuration);
    }

    void StopAttack()
    {
        rb.linearVelocity = Vector2.zero;
        isAttacking = false;
    }
}