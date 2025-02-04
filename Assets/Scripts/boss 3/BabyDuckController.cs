using UnityEngine;

public class BabyDuckController : MonoBehaviour
{
    public float speed = 3f;
    public float explosionRadius = 2f;
    public int explosionDamage = 30;
    public LayerMask playerLayer;
    
    private Transform target;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    public void Initialize(Transform target, float speed, float explosionRadius, int explosionDamage)
    {
        this.target = target;
        this.speed = speed;
        this.explosionRadius = explosionRadius;
        this.explosionDamage = explosionDamage;
    }

    void Update()
    {
        if (target != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, explosionRadius, playerLayer);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>()?.TakeDamage(explosionDamage);
        }

        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}