using UnityEngine;

public class RhinoChargeAttack : MonoBehaviour
{
    public float chargeSpeed = 10f;
    public float chargeDuration = 2f;
    public int damage = 50;
    public float cooldownTime = 5f;
    private float nextChargeTime = 0f;
    private bool isCharging = false;
    private Vector2 chargeDirection;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextChargeTime && !isCharging)
        {
            StartCharge();
        }
    }

    void StartCharge()
    {
        nextChargeTime = Time.time + cooldownTime;
        isCharging = true;
        animator.SetTrigger("Charge"); 
        chargeDirection = (Vector2)(transform.right); 
        StartCoroutine(Charge());
    }

    System.Collections.IEnumerator Charge()
    {
        float elapsedTime = 0f;

        while (elapsedTime < chargeDuration)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)chargeDirection, chargeSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isCharging = false;
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
        }
    }
}