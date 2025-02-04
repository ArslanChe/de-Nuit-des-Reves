using UnityEngine;

public class Egg : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Destroy(gameObject); 
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    
}