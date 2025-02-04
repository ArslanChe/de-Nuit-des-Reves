using UnityEngine;

public class FeatherController : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 5f;
    public int damage = 10;

    private Vector3 direction;

    void Start()
    {
        Destroy(gameObject, lifetime); 
    }

    public void Initialize(Vector3 direction, float speed, float lifetime, int damage)
    {
        this.direction = direction;
        this.speed = speed;
        this.lifetime = lifetime;
        this.damage = damage;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime); 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Destroy(gameObject); 
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.2f);
    }
}