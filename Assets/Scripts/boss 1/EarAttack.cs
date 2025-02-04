using UnityEngine;

public class EarAttack : MonoBehaviour
{
    public GameObject earWavePrefab;
    public Transform leftEarPoint; 
    public Transform rightEarPoint; 
    public float attackRange = 5f; 
    public float attackCooldown = 3f; 
    public float waveSpeed = 7f;

    private Transform player;
    private float nextAttackTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        
        GameObject leftWave = Instantiate(earWavePrefab, leftEarPoint.position, Quaternion.identity);
        GameObject rightWave = Instantiate(earWavePrefab, rightEarPoint.position, Quaternion.identity);

        
        Rigidbody2D rbLeft = leftWave.GetComponent<Rigidbody2D>();
        Rigidbody2D rbRight = rightWave.GetComponent<Rigidbody2D>();

        rbLeft.linearVelocity = new Vector2(-waveSpeed, 0); 
        rbRight.linearVelocity = new Vector2(waveSpeed, 0); 
    }
}