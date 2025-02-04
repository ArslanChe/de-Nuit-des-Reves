using UnityEngine;

public class DuckPhaseController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int phase2HealthThreshold = 50; 
    public GameObject phase2AttackPrefab; 

    private bool phase2Activated = false;

    public DuckFeatherAttack featherAttackScript;  
    public DuckSoundWaveAttack soundWaveAttackScript; 

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= phase2HealthThreshold && !phase2Activated)
        {
            ActivatePhase2();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ActivatePhase2()
    {
        phase2Activated = true;

        featherAttackScript.enabled = false;
        soundWaveAttackScript.enabled = false;

        GameObject newAttack = Instantiate(phase2AttackPrefab, transform.position, Quaternion.identity);
        Phase2Attack phase2Attack = newAttack.GetComponent<Phase2Attack>();
        phase2Attack.Initialize(gameObject.transform);

        Debug.Log("Утка перешла во вторую фазу!");
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Утка уничтожена!");
    }
}