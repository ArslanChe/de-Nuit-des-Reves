using UnityEngine;

public class RhinoBossController : MonoBehaviour
{
    public float maxHealth = 500f;
    private float currentHealth;
    private float phase2HealthThreshold = 0.6f;
    private float phase3HealthThreshold = 0.3f;
    private bool isInPhase2 = false;
    private bool isInPhase3 = false;

    public RhinoChargeAttack chargeAttack;
    public RhinoStompAttack stompAttack;
    public RhinoDirtAttack dirtAttack;
    public RhinoStoneThrow stoneThrow;
    public RhinoChargeAttackPhase2 chargeAttackPhase2;
    public int initialDamage = 80;
    public int phase2Damage = 100;
    public int phase3Damage = 120;

    void Start()
    {
        currentHealth = maxHealth;
        chargeAttack = GetComponent<RhinoChargeAttack>();
        stompAttack = GetComponent<RhinoStompAttack>();
        dirtAttack = GetComponent<RhinoDirtAttack>();
        stoneThrow = GetComponent<RhinoStoneThrow>();
        chargeAttackPhase2 = GetComponent<RhinoChargeAttackPhase2>();
    }

    void Update()
    {
        if (currentHealth / maxHealth <= phase3HealthThreshold && !isInPhase3)
        {
            SwitchToPhase3();
        }
        else if (currentHealth / maxHealth <= phase2HealthThreshold && !isInPhase2)
        {
            SwitchToPhase2();
        }

        if (isInPhase3)
        {
            PerformPhase3Attacks();
        }
        else if (isInPhase2)
        {
            PerformPhase2Attacks();
        }
        else
        {
            PerformPhase1Attacks();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
    }

    void SwitchToPhase2()
    {
        isInPhase2 = true;
        chargeAttack.damage = phase2Damage;
        stompAttack.stompDamage = 60;
        dirtAttack.dirtDamage = 40;
    }

    void SwitchToPhase3()
    {
        isInPhase3 = true;
        chargeAttack.damage = phase3Damage;
        stompAttack.stompDamage = 100;
        dirtAttack.dirtDamage = 80;
    }
    //todo совместить атаки
    void PerformPhase1Attacks()
    {
        if (Random.value < 0.5f)
        {
            //chargeAttack.StartChargeAttack();
        }
        else
        {
            //stompAttack.PerformStomp();
        }
    }

    void PerformPhase2Attacks()
    {
        if (Random.value < 0.4f)
        {
            chargeAttackPhase2.StartCharge(FindObjectOfType<PlayerHealth>().transform.position);
        }
        else if (Random.value < 0.6f)
        {
            //stoneThrow.ThrowStone();
        }
        else
        {
            //dirtAttack.SpawnDirt();
        }
    }

    void PerformPhase3Attacks()
    {
        //chargeAttackPhase2.StartCharge(FindObjectOfType<PlayerHealth>().transform.position);
        //stoneThrow.ThrowStone();
    }
}
