using UnityEngine;

public class MushroomBoss : MonoBehaviour
{
    public float maxHealth = 300f;
    private float currentHealth;
    public GameObject marioPrefab;
    public float marioAttackCooldown = 7f;
    private float nextMarioAttackTime = 0f;
    public float attackRange = 10f;

    private Transform player;

    void Start()
    {
        currentHealth = maxHealth;
        player = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        if (Time.time >= nextMarioAttackTime)
        {
            PerformMarioSummonAttack();
        }
    }

    void PerformMarioSummonAttack()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            nextMarioAttackTime = Time.time + marioAttackCooldown;
            SummonMario();
        }
    }

    void SummonMario()
    {
        GameObject mario = Instantiate(marioPrefab, transform.position, Quaternion.identity);
        MarioSummonAttack marioSummonAttack = mario.GetComponent<MarioSummonAttack>();
        if (marioSummonAttack != null)
        {
            marioSummonAttack.Initialize(player.position);
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