using UnityEngine;

public class RhinoChargeAttackPhase2 : MonoBehaviour
{
    public float chargeSpeed = 15f;
    public float chargeDuration = 2f;
    public int chargeDamage = 100;
    private float chargeTimer = 0f;
    private Vector3 targetPosition;
    private bool isCharging = false;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        if (isCharging)
        {
            Charge();
        }
    }

    public void StartCharge(Vector3 target)
    {
        targetPosition = target;
        isCharging = true;
        chargeTimer = chargeDuration;
    }

    void Charge()
    {
        if (chargeTimer > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, chargeSpeed * Time.deltaTime);
            chargeTimer -= Time.deltaTime;
        }
        else
        {
            isCharging = false;
            DealChargeDamage();
        }
    }

    void DealChargeDamage()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, 1f); 
        foreach (Collider2D hit in hitPlayers)
        {
            if (hit.CompareTag("Player"))
            {
                PlayerHealth health = hit.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.TakeDamage(chargeDamage);
                }
            }
        }
    }
}