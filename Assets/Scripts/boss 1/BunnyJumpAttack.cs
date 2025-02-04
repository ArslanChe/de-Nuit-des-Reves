using UnityEngine;

public class BunnyJumpAttack : MonoBehaviour
{
    public float jumpForce = 12f;
    public float attackCooldown = 5f; 
    public GameObject shockwavePrefab; 

    private Transform player;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private float nextAttackTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null || Time.time < nextAttackTime || isJumping) return;

        JumpToPlayer();
        nextAttackTime = Time.time + attackCooldown;
    }

    void JumpToPlayer()
    {
        isJumping = true;
        Vector2 jumpTarget = new Vector2(player.position.x, transform.position.y);
        rb.linearVelocity = new Vector2((jumpTarget.x - transform.position.x) * 1.5f, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isJumping)
        {
            isJumping = false;
            CreateShockwave();
        }
    }

    void CreateShockwave()
    {
        Instantiate(shockwavePrefab, transform.position, Quaternion.identity);
    }
}