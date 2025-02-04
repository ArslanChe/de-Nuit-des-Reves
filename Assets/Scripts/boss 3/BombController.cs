using UnityEngine;

public class BombController : MonoBehaviour
{
    public float speed = 4f;
    public int damage = 50;
    public float explosionRadius = 2f;

    private Vector3 targetPosition;

    void Start()
    {
        Destroy(gameObject, 5f); 
    }

    public void Initialize(Vector3 targetPosition, float speed, int damage)
    {
        this.targetPosition = targetPosition;
        this.speed = speed;
        this.damage = damage;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) <= 0.2f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }

        Destroy(gameObject); 
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}