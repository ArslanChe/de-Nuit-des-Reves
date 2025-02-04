using UnityEngine;

public class DuckController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int phase2HealthThreshold = 50;
    public GameObject phase2AttackPrefab;

    public float moveSpeed = 5f;
    public float attackCooldown = 2f;
    public float moveDirectionChangeCooldown = 3f;
    private float nextMoveTime = 0f;
    private float nextAttackTime = 0f;
    private bool isInPhase2 = false;

    private Rigidbody2D rb;
    private Vector2 currentDirection;
    private DuckFeatherAttack featherAttack;
    private DuckSoundWaveAttack soundWaveAttack;
    private DuckPhaseController phaseController;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        featherAttack = GetComponent<DuckFeatherAttack>();
        soundWaveAttack = GetComponent<DuckSoundWaveAttack>();
        phaseController = GetComponent<DuckPhaseController>();
    }

    void Update()
    {
        if (currentHealth <= phase2HealthThreshold && !isInPhase2)
        {
            ActivatePhase2();
        }

        if (Time.time >= nextMoveTime)
        {
            MoveRandomly();
            nextMoveTime = Time.time + moveDirectionChangeCooldown;
        }

        if (Time.time >= nextAttackTime)
        {
            PerformAttack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void MoveRandomly()
    {
        float moveX = Random.Range(-1f, 1f);
        float moveY = Random.Range(-1f, 1f);
        currentDirection = new Vector2(moveX, moveY).normalized;
        rb.linearVelocity = currentDirection * moveSpeed;
    }

    void PerformAttack()
    {
        if (isInPhase2)
        {
            LaunchBombs();
        }
        else
        {
            //featherAttack.PerformFeatherAttack();
            //soundWaveAttack.PerformSoundWaveAttack();
        }
    }

    void LaunchBombs()
    {
        GameObject bomb = Instantiate(phase2AttackPrefab, transform.position, Quaternion.identity);
        BombController bombController = bomb.GetComponent<BombController>();
        bombController.Initialize(transform.position, 4f, 50); 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ActivatePhase2()
    {
        isInPhase2 = true;
        featherAttack.enabled = false;
        soundWaveAttack.enabled = false;

        Debug.Log("Утка перешла во вторую фазу!");
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Утка уничтожена!");
    }
}
