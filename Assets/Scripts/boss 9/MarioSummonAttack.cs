using UnityEngine;

public class MarioSummonAttack : MonoBehaviour
{
    private Vector3 targetPosition;
    public int speed = 10;
    public int damage = 30;

    public void Initialize(Vector3 target)
    {
        targetPosition = target;
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        if (targetPosition != null)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 1f)
            {
                PerformAttack();
            }
        }
    }

    void PerformAttack()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
        Destroy(gameObject); 
    }
}