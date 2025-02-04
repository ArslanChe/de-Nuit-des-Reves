using UnityEngine;

public class Stone : MonoBehaviour
{
    public int damage = 60;

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

    public void InitializeStone(int damageAmount)
    {
        damage = damageAmount;
    }
}