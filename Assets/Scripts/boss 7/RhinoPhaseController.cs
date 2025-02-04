using UnityEngine;

public class RhinoPhaseController : MonoBehaviour
{
    public float phase2HealthThreshold = 0.6f;
    public float phase3HealthThreshold = 0.3f;
    public int phase2Damage = 80;
    public int phase3Damage = 120;
    private int initialDamage;
    private int currentDamage;
    private PlayerHealth playerHealth;
    private RhinoChargeAttack chargeAttack;
    private RhinoStompAttack stompAttack;
    private RhinoDirtAttack dirtAttack;
    private float maxHealth;
    private float currentHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        chargeAttack = GetComponent<RhinoChargeAttack>();
        stompAttack = GetComponent<RhinoStompAttack>();
        dirtAttack = GetComponent<RhinoDirtAttack>();
        maxHealth = 100f;  
        currentHealth = maxHealth;
        initialDamage = chargeAttack.damage;
        currentDamage = initialDamage;
    }

    void Update()
    {
        if (currentHealth / maxHealth <= phase3HealthThreshold)
        {
            SwitchToPhase3();
        }
        else if (currentHealth / maxHealth <= phase2HealthThreshold)
        {
            SwitchToPhase2();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
    }

    void SwitchToPhase2()
    {
        if (currentDamage == initialDamage)
        {
            chargeAttack.damage = phase2Damage;
            stompAttack.stompDamage = 60;
            dirtAttack.dirtDamage = 40;
            currentDamage = phase2Damage;
        }
    }

    void SwitchToPhase3()
    {
        if (currentDamage == phase2Damage)
        {
            chargeAttack.damage = phase3Damage;
            stompAttack.stompDamage = 100;
            dirtAttack.dirtDamage = 80;
            currentDamage = phase3Damage;
        }
    }
}