using UnityEngine;

public class SkeletonMeleeAttack : MonoBehaviour
{
    public int attackDamage = 20;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f; 
    private float nextAttackTime = 0f;

    private Transform player;
    private SkeletonShieldBlock shieldBlockScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shieldBlockScript = GetComponent<SkeletonShieldBlock>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime && !shieldBlockScript.IsBlocking())
        {
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                PerformMeleeAttack();
            }
        }
    }

    void PerformMeleeAttack()
    {
        nextAttackTime = Time.time + attackCooldown;  
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, attackRange, LayerMask.GetMask("Player"));

        if (playerCollider != null)
        {
            PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage); 
                Debug.Log("Скелет атакует мечом, нанося " + attackDamage + " урона!");
            }
        }
    }
}