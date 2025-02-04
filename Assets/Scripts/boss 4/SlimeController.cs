using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float slimeSpeed = 5f; 
    public int slimeDamage = 20;  
    public float lifetime = 3f;    

    private Vector3 targetPosition;

    void Start()
    {
        Destroy(gameObject, lifetime); 
    }

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
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, slimeSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(slimeDamage);
            }
            Destroy(gameObject);  
        }
    }
}