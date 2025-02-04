using UnityEngine;

public class Dirt : MonoBehaviour
{
    public float dirtSpeed = 3f;
    public float lifetime = 5f;
    public int damage = 20;
    private Transform player;
    private float timeAlive = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        Destroy(gameObject, lifetime); 
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * dirtSpeed * Time.deltaTime; 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Destroy(gameObject); 
            }
        }
    }

    public void InitializeDirt(float speed, float lifeTime, int damageAmount)
    {
        dirtSpeed = speed;
        lifetime = lifeTime;
        damage = damageAmount;
    }
}