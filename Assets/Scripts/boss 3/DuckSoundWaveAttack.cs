using UnityEngine;

public class DuckSoundWaveAttack : MonoBehaviour
{
    public float attackCooldown = 5f;
    public float maxRange = 10f;
    public int maxDamage = 50;
    public float attackDuration = 1f;
    public LayerMask playerLayer;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            SoundWaveAttack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void SoundWaveAttack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, maxRange, playerLayer);

        foreach (Collider2D player in hitPlayers)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            int damage = Mathf.RoundToInt((1 - (distance / maxRange)) * maxDamage);
            player.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxRange);
    }
}