using UnityEngine;

public class Bone : MonoBehaviour
{
    private int damage;

    public void SetDamage(int damageValue)
    {
        damage = damageValue;
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