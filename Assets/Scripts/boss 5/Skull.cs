using UnityEngine;

public class Skull : MonoBehaviour
{
    public int damage = 25;  
    public float lifetime = 3f; 

    void Start()
    {
        Destroy(gameObject, lifetime); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); 
            }
            Destroy(gameObject);  
        }
    }
}