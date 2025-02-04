using UnityEngine;

public class BunnyEggThrow : MonoBehaviour
{
    public GameObject eggPrefab; 
    public Transform throwPoint;
    public float throwForce = 10f;
    public float attackRange = 7f;
    public float attackCooldown = 3f; 

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
            ThrowEgg();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void ThrowEgg()
    {
        GameObject egg = Instantiate(eggPrefab, throwPoint.position, Quaternion.identity);
        Rigidbody2D rb = egg.GetComponent<Rigidbody2D>();

        Vector2 direction = (player.position - throwPoint.position).normalized;
        rb.linearVelocity = direction * throwForce;
    }
}