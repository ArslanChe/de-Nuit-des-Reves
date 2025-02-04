using UnityEngine;

public class ElectricBolt : MonoBehaviour
{
    public int speed = 10;
    public int damage = 20;
    public int lifetime = 5;
    private Vector3 direction;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        MoveBolt();
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void MoveBolt()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
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