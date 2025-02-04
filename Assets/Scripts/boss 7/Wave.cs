using UnityEngine;

public class Wave : MonoBehaviour
{
    public float waveSpeed = 5f;
    public float waveRadius = 3f;
    public int damage = 40;
    private float currentRadius = 0f;

    void Update()
    {
        if (currentRadius < waveRadius)
        {
            currentRadius += waveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(currentRadius, currentRadius, 1f);
            CheckForCollision();
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void CheckForCollision()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, currentRadius);
        foreach (Collider2D hit in hitObjects)
        {
            if (hit.CompareTag("Player"))
            {
                PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                }
            }
        }
    }

    public void InitializeWave(float speed, float radius, int damageAmount)
    {
        waveSpeed = speed;
        waveRadius = radius;
        damage = damageAmount;
    }
}