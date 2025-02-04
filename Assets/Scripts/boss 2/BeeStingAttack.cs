using UnityEngine;

public class BeeStingAttack : MonoBehaviour
{
    public GameObject stingPrefab;
    public Transform stingSpawnPoint;
    public float attackRange = 5f;
    public float attackCooldown = 3f;
    public float stingSpeed = 7f;
    public float returnSpeed = 5f;
    public float rotationSpeed = 500f;

    private Transform player;
    private float nextAttackTime = 0f;
    private bool stingReturning = false;
    private GameObject currentSting;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null || Time.time < nextAttackTime) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange && currentSting == null)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        currentSting = Instantiate(stingPrefab, stingSpawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = currentSting.GetComponent<Rigidbody2D>();

        Vector2 direction = (player.position - stingSpawnPoint.position).normalized;
        rb.linearVelocity = direction * stingSpeed;

        stingReturning = false;
        StartCoroutine(ReturnStingAfterTime(1f));
    }

    System.Collections.IEnumerator ReturnStingAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        stingReturning = true;
    }

    void FixedUpdate()
    {
        if (stingReturning && currentSting != null)
        {
            Vector2 direction = (transform.position - currentSting.transform.position).normalized;
            Rigidbody2D rb = currentSting.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * returnSpeed;

            currentSting.transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);

            if (Vector2.Distance(transform.position, currentSting.transform.position) < 0.5f)
            {
                Destroy(currentSting);
                stingReturning = false;
            }
        }
    }
}
