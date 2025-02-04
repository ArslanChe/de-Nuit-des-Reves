using UnityEngine;

public class SlimeEatPlayer : MonoBehaviour
{
    public int damage = 50;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Destroy(collision.gameObject);
                EatPlayer();
            }
        }
    }

    void EatPlayer()
    {
        Destroy(gameObject);
    }
}